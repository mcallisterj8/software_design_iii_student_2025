using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrefleApp.Models.Trefle.Dtos;
using TrefleApp.Services;

namespace TrefleApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TrefleController : ControllerBase {

        private readonly TrefleService _trefleService;

        public TrefleController(TrefleService trefleService) {
            _trefleService = trefleService;
        }

        [HttpGet("plants/{plantId}")]
        public async Task<ActionResult<PlantDto>> GetPlantById(int plantId) {
            // TODO: Complete
            return Ok();
        }

        [HttpGet("plants")]
        public async Task<ActionResult<ICollection<PlantDto>>> GetPlants() {
            // TODO: Complete
            return Ok();
        }
    }
}
