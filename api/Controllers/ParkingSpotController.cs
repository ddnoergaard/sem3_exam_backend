using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Repositories;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingSpotController : ControllerBase
    {
        private readonly ParkingSpotRepository _parkingSpotRepository;

        public ParkingSpotController(ParkingSpotRepository parkingSpotRepository)
        {
            _parkingSpotRepository = parkingSpotRepository;
        }

        // GetAll
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<ParkingSpot>> Get()
        {
            IEnumerable<ParkingSpot> spots = _parkingSpotRepository.GetAll();

            if (!spots.Any())
            {
                return NoContent();
            }

            return Ok(spots);
        }

        // GetById
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ParkingSpot> Get(int id)
        {
            ParkingSpot? spot = _parkingSpotRepository.GetById(id);

            if (spot == null)
            {
                return NotFound("No such parking spot, id: " + id);
            }

            return Ok(spot);
        }

        // GetByZone
        [HttpGet("zone/{zone}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<ParkingSpot>> GetByZone(string zone)
        {
            IEnumerable<ParkingSpot> spots = _parkingSpotRepository.GetByZone(zone);

            if (!spots.Any())
            {
                return NoContent();
            }

            return Ok(spots);
        }
    }
}