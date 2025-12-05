using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityExample.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class UnguardedController : ControllerBase {

        [HttpGet("")]
        public async Task<ActionResult> Greeting() {
            return Ok("Hello from the UnguardedController!");
        }

        [Authorize]
        [HttpGet("guarded-endpoint")]
        public async Task<ActionResult> GuardedExample() {
            return Ok("Unguarded controller, but guarded endpoint.");
        }
    }
}
