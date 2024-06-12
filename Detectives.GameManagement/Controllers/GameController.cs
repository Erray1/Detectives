using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Detectives.GameManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpPost("/create")]
        public async Task<IActionResult> CreateGame()
        {

        }

        [HttpGet("/join")]
        public async Task<IActionResult> JoinGame()
        {

        }
    }
}
