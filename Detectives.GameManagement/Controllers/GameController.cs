using Ardalis.Result;
using Detectives.Entities;
using Detectives.GameManagement.Domain.Dto;
using Detectives.GameManagement.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Detectives.GameManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameManagementController : ControllerBase
    {
        private readonly IJoinGameService _joinGameService;
        private readonly ICreateGameService _createGameService;
        public GameManagementController(
            IJoinGameService joinGameService,
            ICreateGameService createGameService)
        {
            _joinGameService = joinGameService;
            _createGameService = createGameService;

        }

        [HttpPost("/create")]
        public async Task<IActionResult> CreateGame([FromBody] CreateGameRequest request)
        {
            var result = await _createGameService.CreateGame(request);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Errors);
            }
            return RedirectToAction(nameof(this.JoinGame), (object)result.Value.Value);
        }

        [HttpGet("/join/{gameId}")]
        public async Task<IActionResult> JoinGame(string gameId)
        {
            var result = await _joinGameService.JoinGame(gameId);
            if (!result.IsSuccesful)
            {
                return result.StatusCode switch
                {
                    JoinGameStatusCode.NotFound => NotFound($"Игра с id {gameId} не найдена"),
                    JoinGameStatusCode.Closed => BadRequest($"Игра с id {gameId} уже началась"),
                    JoinGameStatusCode.MaxPlayers => BadRequest($"Игра с id {gameId} заполнена"),
                    _ => throw new ArgumentException($"Неверный аргумент")
                };
            }
            return Redirect($"/game?connectionToken={result.ConnectionToken}");
        }
    }
}
