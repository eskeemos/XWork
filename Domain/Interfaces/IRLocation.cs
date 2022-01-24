using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRLocation
    {
        Location GetById(int id);
        Location Add(Location location);
        void Update(Location location);
        void Remove(int id);
    }
}
