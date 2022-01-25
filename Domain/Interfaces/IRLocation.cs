using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRLocation
    {
        Location GetById(int id);
        void Update(Location location);
    }
}
