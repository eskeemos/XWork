using Domain.Entities;
using Domain.Interfaces;
using Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastucture.Repositories
{
    public class AccountRepo : IRAccount
    {
        private readonly Context context;

        public AccountRepo(Context context)
        {
            this.context = context;
        }

        public int Add(Account account)
        {
            context.Account.Add(account);
            context.SaveChanges();

            return account.Id;
        }

        public IEnumerable<Account> Get()
        {
            return context.Account
                .Include(x => x.PersonalData)
                .Include(x => x.Location)
                .ToList();
        }

        public Account GetById(int id)
        {
            return context.Account
                .Include(x => x.PersonalData)
                .Include(x => x.Location)
                .SingleOrDefault(x => x.Id == id);
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
