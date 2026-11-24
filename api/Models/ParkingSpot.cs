namespace api.Models
{
    public class ParkingSpot
    {
        // properties
        public int Id { get; set; }
        public string Zone { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int AvailableSpots { get; set; }
        public bool IsFull { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Zone: {Zone} Capacity: {Capacity} AvailableSpots: {AvailableSpots} IsFull: {IsFull}";
        }
    }
}