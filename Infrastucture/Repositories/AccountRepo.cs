using Domain.Entities;
using Domain.Interfaces;
using Infrastucture.Data;
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

        public Account Add(Account account)
        {
            context.Account.Add(account);
            context.SaveChanges();

            return account;
        }

        //public IEnumerable<Account> Get()
        //{
        //    return datas;
        //}

        //public Account GetById(int id)
        //{
        //    return datas.SingleOrDefault(x => x.Id == id);
        //}

        //public void Remove(int id)
        //{
        //    datas.Remove(GetById(id));
        //}

        //public void Update(Account client)
        //{
        //    var x = client;
        //}
    }
}
