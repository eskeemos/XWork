using Domain.Entities;
using Domain.Interfaces;
using Infrastucture.Data;
using System.Collections.Generic;
using System.Linq;

namespace Infrastucture.Repositories
{
    public class PersonalDataRepo : IRPersonalData
    {
        private readonly Context context;
        public PersonalDataRepo(Context context)
        {
            this.context = context;
        }
        //public static readonly ISet<PersonalData> datas = new HashSet<PersonalData>()
        //{
        //    new PersonalData()
        //    {
        //        Id = 1,
        //        Name = "n1",
        //        LastName = "ln1",
        //        Email = "e1",
        //        Phone = "p1",
        //        Pesel = "pe1",
        //        SanitaryBook = false,
        //        BankAccount = "ba1"
        //    },
        //    new PersonalData()
        //    {
        //        Id = 2,
        //        Name = "n2",
        //        LastName = "ln2",
        //        Email = "e2",
        //        Phone = "p2",
        //        Pesel = "pe2",
        //        SanitaryBook = false,
        //        BankAccount = "ba2"
        //    }
        //};
        

        public PersonalData Add(PersonalData personalData)
        {
            context.Add(personalData);
            context.SaveChanges();
            return personalData;
        }

        public PersonalData GetById(int id)
        {
            return context.PersonalDatas.SingleOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            context.Remove(GetById(id));
            context.SaveChanges();
        }

        public void Update(PersonalData personalData)
        {
            context.PersonalDatas.Update(personalData);
            context.SaveChanges();
        }
    }
}
