using api.Models;

namespace api.Interfaces
{
    public interface IParkingSpotRepository
    {
        IEnumerable<ParkingSpot> GetAll();

        IEnumerable<ParkingSpot> GetByZone(string zone);

        ParkingSpot? GetById(int id);
    }
}