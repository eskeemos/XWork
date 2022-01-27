using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRZusStatement
    {
        ZusStatement GetById(int id);
        void Update(ZusStatement zusStatement); 
    }
}
