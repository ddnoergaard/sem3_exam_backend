namespace api.Models
{
    public class Car
    {
        // properties
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public DateTime TimeArrived { get; set; }
        public DateTime? TimeDeparted { get; set; }

        // ToString method
        public override string ToString()
        {
            return $"Car Id: {Id}, License Plate: {LicensePlate}, Time Arrived: {TimeArrived}, Time Departed: {TimeDeparted}";
        }
    }
}
