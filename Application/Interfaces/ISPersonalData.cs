using Application.Dtos;

namespace Application.Interfaces
{
    public interface ISPersonalData
    {
        PersonalDataDto GetPDById(int id);
        void UpdatePD(UpdatePersonalDataDto dto);   
    }
}
