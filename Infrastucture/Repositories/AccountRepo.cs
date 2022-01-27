using Domain.Entities;
using Domain.Entities.Helpers;
using Domain.Interfaces;
using Infrastucture.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
    public class AccountRepo : IRAccount 
    {
        private readonly Context context;
        private readonly IPasswordHasher<Account> hasher;
        private readonly IConfiguration configuration;

        public AccountRepo(Context context, IPasswordHasher<Account> hasher, IConfiguration configuration)
        {
            this.context = context;
            this.hasher = hasher;
            this.configuration = configuration;
        }

        public IEnumerable<Account> Get()
        {
            return context.Account
                .ToList();
        }

        public Account GetById(int id)
        {
            return context.Account
                .SingleOrDefault(x => x.Id == id);
        }

        public LogData Login(Account account)
        {
            var mail = context.Account.SingleOrDefault(x => x.Email == account.Email);

            if (mail is null) return new LogData() { Error = "User with this email don't exists" };

            var res = hasher.VerifyHashedPassword(account, mail.Password, account.Password);

            if (res == PasswordVerificationResult.Failed)
                return new LogData() { Error = "Incorrect Password" };

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString())
            };

            var cfg = configuration.GetSection("Authentication");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(cfg["JwtKey"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(int.Parse(cfg["JwtExpire"].ToString()));

            var token = new JwtSecurityToken(
                cfg["JwtIssuer"],
                cfg["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();

            var JWT = tokenHandler.WriteToken(token);
            var Id = context.Account
                .SingleOrDefault(x => x.Email == account.Email).Id;
            var Name = context.Account
                .Include(x => x.PersonalData)
                .SingleOrDefault(x => x.Email == account.Email)
                .PersonalData.Name;
            var RoleId = context.Account
                .SingleOrDefault(x => x.Email == account.Email).RoleId;

            return new LogData() { Id = Id, JWT = JWT, RoleId = RoleId, Name = Name };
        }

        public int Post(Account account)
        {
            if (account.RoleId == 0) account.RoleId = 1;

            var hashedPassword = hasher.HashPassword(account, account.Password);
            account.Password = hashedPassword;

            context.Account.Add(account);
            context.SaveChanges();
            return account.Id;
        }

        public void Remove(int id)
        {
            context.Account.Remove(GetById(id));
            context.SaveChanges();
        }

        public void Update(Account account)
        {
            var data = GetById(account.Id);
            if (data is null) return;
            data.Password = account.Password;
            context.SaveChanges();
        }
    }
}
