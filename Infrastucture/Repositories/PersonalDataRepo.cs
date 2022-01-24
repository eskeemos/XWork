using Domain.Entities;
using Domain.Interfaces;
using Infrastucture.Data;
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
        
        public PersonalData Add(PersonalData personalData)
        {
            context.PersonalData.Add(personalData);
            context.SaveChanges();
            return personalData;
        }

        public PersonalData GetById(int id)
        {
            return context.PersonalData.SingleOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            context.PersonalData.Remove(GetById(id));
            context.SaveChanges();
        }

        public void Update(PersonalData personalData)
        {
            context.PersonalData.Update(personalData);
            context.SaveChanges();
        }
    }
}
