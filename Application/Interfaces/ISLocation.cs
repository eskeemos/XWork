using Application.Dtos;

namespace Application.Interfaces
{
    public interface ISLocation
    {
        LocationDto GetLocationById(int id);
        UpdateLocationDto Add(LocationDto location);
        void Update(UpdateLocationDto location);
        void Remove(int id);
    }
}
