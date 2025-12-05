using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace IdentityExample.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GuardedController : ControllerBase {

        [HttpGet("")]
        public async Task<ActionResult> Greeting() {
            return Ok("Hello from the GuardedController!");
        }

        [AllowAnonymous]
        [HttpGet("unguarded-endpoint")]
        public async Task<ActionResult> UnguardedExample() {
            return Ok("Guarded controller, but unguarded endpoint.");
        }

    }
}
