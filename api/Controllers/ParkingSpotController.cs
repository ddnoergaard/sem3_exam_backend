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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public ActionResult<>



    }



}
