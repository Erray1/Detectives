using Ardalis.Result;
using Detectives.GameService.Domain;
using Detectives.GameService.Domain.Communication;
using Detectives.GameService.GamesCache;
using Microsoft.AspNetCore.Mvc;

namespace Detectives.GameService.Controllers;
[ApiController]
[Route("[conroller]")]
public class GamesController : ControllerBase
{
    private readonly IGamesCacheService _gamesCache;
    public GamesController(IGamesCacheService gamesCache)
    {
        _gamesCache = gamesCache;
    }
    [HttpGet("connect/{gameId}")]
    public async Task<IActionResult> Connect(string gameId, [FromQuery] string connectionId)
    {
        var result = _gamesCache.TryAddPlayer(gameId, connectionId);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Errors);
        }
        string connectionToken = result.Value.ConnectionToken;
        return Redirect($"/game/{gameId}?connectionToken={connectionToken}");
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateGameRequest createGameRequest)
    {
        var game = GameState.FromRequest(createGameRequest);
        _gamesCache.OpenGame()
    }
}

