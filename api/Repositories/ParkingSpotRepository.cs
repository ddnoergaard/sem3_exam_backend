using api.Models;
namespace api.Repositories



{
    public class ParkingSpotRepository
    {
        private List<ParkingSpot> parkingSpots = new List<ParkingSpot>();
        private int NextId = 1;


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
