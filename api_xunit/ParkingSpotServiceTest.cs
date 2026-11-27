using api.Models;
using api.Repositories;
using api.Services;

namespace api_xunit
{
    public class ParkingSpotServiceTest
    {
        [Fact]
        public void CarArrivedTest()
        {
            ParkingSpotRepository repo = new ParkingSpotRepository(includeData: true);
            ParkingSpotService service = new ParkingSpotService(repo);

            ParkingSpot? actual = service.OnChange("A", true);

            Assert.Equal(5, actual!.AvailableSpots); // -1 ledig plads.
            Assert.False(actual.IsFull); // er ikke fuld endu.
        }

        [Fact]
        public void CarLeftTest()
        {
            ParkingSpotRepository repo = new ParkingSpotRepository(includeData: true);
            ParkingSpotService service = new ParkingSpotService(repo);

            service.OnChange("A", true);
            ParkingSpot? actual = service.OnChange("A", false);

            Assert.Equal(6, actual!.AvailableSpots); // +1 ledig plads.
            Assert.False(actual.IsFull); // er ikke fuld endu.
        }

        [Fact]
        public void ZoneBecomesFullTest()
        {
            ParkingSpotRepository repo = new ParkingSpotRepository(includeData: true);
            ParkingSpotService service = new ParkingSpotService(repo);

            // Fyld zone C (4)
            for (int i = 0; i < 4; i++)
            {
                service.OnChange("C", true);
            }
            ParkingSpot? actual = repo.GetByZone("C").FirstOrDefault();

            Assert.Equal(0, actual!.AvailableSpots); // er lig med 0.
            Assert.True(actual.IsFull); // er fuld.
        }

        [Fact]
        public void CarArrivedWhenFullTest()
        {
            ParkingSpotRepository repo = new ParkingSpotRepository(includeData: true);
            ParkingSpotService service = new ParkingSpotService(repo);

            // Fyld zone C (4) og prøv en 5. bil
            for (int i = 0; i < 5; i++)
            {
                service.OnChange("C", true);
            }

            ParkingSpot? actual = repo.GetByZone("C").FirstOrDefault();

            Assert.Equal(0, actual!.AvailableSpots); // går ikke under 0
            Assert.True(actual.IsFull); // er fuld.
        }

        [Fact]
        public void CarLeftWhenEmptyTest()
        {
            ParkingSpotRepository repo = new ParkingSpotRepository(includeData: true);
            ParkingSpotService service = new ParkingSpotService(repo);

            ParkingSpot? actual = service.OnChange("A", false);

            Assert.Equal(6, actual!.AvailableSpots); // går ikke over Capacity
            Assert.False(actual.IsFull); // er ikke fuld endu.
        }
    }
}