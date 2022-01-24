using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRPersonalData
    {
        PersonalData GetById(int id);
        PersonalData Add(PersonalData personalData);
        void Update(PersonalData personalData);
        void Remove(int id);
    }
}
