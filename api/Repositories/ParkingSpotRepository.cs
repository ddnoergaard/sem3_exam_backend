using api.Models;
namespace api.Repositories
{
    public class ParkingSpotRepository
    {
        private List<ParkingSpot> parkingSpots = new List<ParkingSpot>();
        private int NextId = 1;

        // Constructor - tilføjer test data hvis includeData er true
        public ParkingSpotRepository(bool includeData = false)
        {
            if (includeData)
            {
                // Zone A
                parkingSpots.Add(new ParkingSpot { Id = NextId++, Zone = "A", Capacity = 6, AvailableSpots = 6 });

                // Zone B
                parkingSpots.Add(new ParkingSpot { Id = NextId++, Zone = "B", Capacity = 10, AvailableSpots = 10 });

                // Zone C
                parkingSpots.Add(new ParkingSpot { Id = NextId++, Zone = "C", Capacity = 4, AvailableSpots = 4 });
            }
        }

        //Methods

        // GetAll method
        public IEnumerable<ParkingSpot> GetAll()
        {
            return new List<ParkingSpot>(parkingSpots);
        }

        // GetByZone method
        public IEnumerable<ParkingSpot> GetByZone(string zone)
        {
            List<ParkingSpot> TempList = new List<ParkingSpot>(parkingSpots.Where(spot => spot.Zone == zone));
            return TempList;
        }

        // GetById method
        public ParkingSpot? GetById(int id)
        {
            ParkingSpot? spot = parkingSpots.FirstOrDefault(spot => spot.Id == id);
            return spot is not null ? spot : null;
        }
    }
}