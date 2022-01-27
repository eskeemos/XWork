using Application.Dtos.ZusStatementDtos;

namespace Application.Interfaces
{
    public interface ISZusStatement
    {
        ZusStatementDto GetZusStatementById(int id);
        void UpdateZusStatement(UpdateZusStatementDto location);
    }
}
