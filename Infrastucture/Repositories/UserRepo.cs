using Domain.Entities;
using Domain.Interfaces;
using Infrastucture.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

            var cfg = configuration.GetSection("Authentication");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(cfg["JwtKey"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(int.Parse(cfg["ExpireDays"].ToString()));

            var token = new JwtSecurityToken(
                cfg["Issuer"],
                cfg["Issuer"],
                claims,
                expires : expires,
                signingCredentials : cred);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
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
