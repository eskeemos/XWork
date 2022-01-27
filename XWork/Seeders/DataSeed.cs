using Domain.Entities;
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
                if (context.Account.SingleOrDefault(x => x.Email == "admin@wp.pl") is null)
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
                Email = "admin@wp.pl",
                Password = "admin123",
                Location = new Location(),
                ZusStatement = new ZusStatement(),
                PersonalData = new PersonalData() { Name = "Admin" },
                RoleId = 2
            };

            account.Password = hasher.HashPassword(account, account.Password);

            return account;
        }
    }
}
