namespace api.Models
{
    public class ParkingSpot
    {
        // properties
        public int Id { get; set; }
        public int SpotNumber { get; set; }
        public bool IsOccupied { get; set; }
        public string Zone { get; set; }

        // ToString method
        public override string ToString()
        {
            return $"Parking Spot Id: {Id}, Spot Number: {SpotNumber}, Is Occupied: {IsOccupied}, Zone: {Zone}";
        }
    }
}
