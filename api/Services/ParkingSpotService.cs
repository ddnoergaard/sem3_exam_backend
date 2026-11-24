using api.Models;
using api.Repositories;

namespace api.Services
{
    public class ParkingSpotService
    {
        private readonly ParkingSpotRepository _repository;

        public ParkingSpotService(ParkingSpotRepository repository)
        {
            _repository = repository;
        }

        // OnChange - true = bil ankommet, false = bil kørt
        public ParkingSpot? OnChange(string zone, bool signal)
        {
            ParkingSpot? spot = _repository.GetByZone(zone).FirstOrDefault();
            if (spot == null)
            {
                return null;
            }

            if (signal)
            {
                CarArrived(spot);
            }
            else
            {
                CarLeft(spot);
            }

            return spot;
        }

        // CarArrived - tæller 1 ned
        private bool CarArrived(ParkingSpot spot)
        {
            if (spot.IsFull)
            {
                return false; // ingen plads
            }

            spot.AvailableSpots--;

            if (spot.AvailableSpots <= 0)
            {
                spot.AvailableSpots = 0;
                spot.IsFull = true;
            }

            return true;
        }

        // CarLeft - tæller 1 op igen
        private bool CarLeft(ParkingSpot spot)
        {
            if (spot.AvailableSpots >= spot.Capacity)
            {
                return false; // zonen er allerede tom
            }

            spot.AvailableSpots++;
            spot.IsFull = false;

            return true;
        }
    }
}