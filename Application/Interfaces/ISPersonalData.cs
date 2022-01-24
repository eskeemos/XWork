using Application.Dtos;

namespace Application.Interfaces
{
    public interface ISPersonalData
    {
        PersonalDataDto GetPDById(int id);
        UpdatePersonalDataDto Add(PersonalDataDto personalData);
        void UpdatePD(UpdatePersonalDataDto personalData);
        void RemovePD(int id);
    }
}
