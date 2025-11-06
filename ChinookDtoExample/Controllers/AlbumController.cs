using ChinookDtoExample.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChinookDtoExample.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase {
        private readonly ApplicationDbContext _context;

        public AlbumController(ApplicationDbContext context) {
            _context = context;
        }
    }
}
