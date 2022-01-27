using Application.Dtos;

namespace Application.Interfaces
{
    public interface ISLocation
    {
        LocationDto GetLocationById(int id);
        void Update(UpdateLocationDto dto);
    }
}
