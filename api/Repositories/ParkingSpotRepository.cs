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
                parkingSpots.Add(new ParkingSpot { Id = NextId++, SpotNumber = 1, IsOccupied = false, Zone = "A" });
                parkingSpots.Add(new ParkingSpot { Id = NextId++, SpotNumber = 2, IsOccupied = false, Zone = "A" });
                parkingSpots.Add(new ParkingSpot { Id = NextId++, SpotNumber = 3, IsOccupied = true, Zone = "A" });

                // Zone B
                parkingSpots.Add(new ParkingSpot { Id = NextId++, SpotNumber = 1, IsOccupied = false, Zone = "B" });
                parkingSpots.Add(new ParkingSpot { Id = NextId++, SpotNumber = 2, IsOccupied = false, Zone = "B" });
                parkingSpots.Add(new ParkingSpot { Id = NextId++, SpotNumber = 3, IsOccupied = true, Zone = "B" });

                // Zone C
                parkingSpots.Add(new ParkingSpot { Id = NextId++, SpotNumber = 1, IsOccupied = false, Zone = "C" });
                parkingSpots.Add(new ParkingSpot { Id = NextId++, SpotNumber = 2, IsOccupied = false, Zone = "C" });
                parkingSpots.Add(new ParkingSpot { Id = NextId++, SpotNumber = 3, IsOccupied = true, Zone = "C" });
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

        //IsParkingSpotOccupied method ----- VI SÆTTER DEN TIL ET SERVICE LAG SOME TIME -----
        //public bool IsParkingSpotOccupied(int id)
        //{
        //    ParkingSpot? spot = GetById(id);
        //    return spot.IsOccupied;

        //}
    }
}