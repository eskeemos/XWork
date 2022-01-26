using Domain.Entities;
using Domain.Interfaces;
using Infrastucture.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Infrastucture.Repositories
{
    public class UserRepo : IRUser
    {
        private readonly Context context;
        private readonly IPasswordHasher<User> hasher;
        private readonly IConfiguration configuration;

        public UserRepo(Context context, IPasswordHasher<User> hasher, IConfiguration configuration)
        {
            this.context = context;
            this.hasher = hasher;
            this.configuration = configuration;
        }

        public string GetJwt(User user)
        {
            var mail = context.User.SingleOrDefault(x => x.Email == user.Email);

            if(mail is null) return "User with this email don't exists";

            var res = hasher.VerifyHashedPassword(user, mail.Password,user.Password);

            if (res == PasswordVerificationResult.Failed) return "Incorrect Password";

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Authentication")["JwtKey"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //var c = configuration.GetSection("Authentication")["JwtKey"];
            //var expires = DateTime.Now.AddDays(c);
            return "";
        }

        public int Post(User user)
        {
            if(user.RoleId == 0) user.RoleId = 1;

            var hashedPassword = hasher.HashPassword(user, user.Password);
            user.Password = hashedPassword;

            context.User.Add(user);
            context.SaveChanges();
            return user.Id;
        }
    }
}
