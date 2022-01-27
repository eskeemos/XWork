﻿using Domain.Entities;
using Infrastucture.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace XWork.Seeders
{
    public class DataSeed
    {
        private readonly Context context;
        private readonly IPasswordHasher<Account> hasher;

        public DataSeed(Context context, IPasswordHasher<Account> hasher)
        {
            this.context = context;
            this.hasher = hasher;
        }

        public void Seed()
        {
            if(context.Database.CanConnect())
            {
                if(!context.Role.Any())
                {
                    var roles = GetRoles();
                    context.Role.AddRange(roles);
                    context.SaveChanges();
                }
                if (context.Account.SingleOrDefault(x => x.Email == "admin") == null)
                {
                    var admin = GetAdmin();
                    context.Account.Add(admin);
                    context.SaveChanges();
                }
            }
        }
        public IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };

            return roles;
        }

        public Account GetAdmin()
        {
            var account = new Account()
            {
                Email = "admin",
                Password = "admin123",
                Location = new Location(),
                PersonalData = new PersonalData() { Name = "Admin" },
                RoleId = 2
            };
            var hashedPassword = hasher.HashPassword(account, account.Password);
            account.Password = hashedPassword;
            return account;
        }
    }
}
