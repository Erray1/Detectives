using Ardalis.Result;
using Detectives.GameService.Domain;
using Detectives.GameService.Domain.Services;
using Detectives.GameService.GamesCache;
using Detectives.GameService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Detectives.GameService.Hubs;
public class GameHub : Hub
{
    private readonly IGamesCacheService _gamesCache;
    private readonly IGroupsCacheService _groupsCache;
    private readonly MoveHandler _moveHandler;
    public GameHub(
        IGamesCacheService gamesCache,
        IGroupsCacheService groupsCache,
        MoveHandler moveHandler)
    {
        _gamesCache = gamesCache;
        _groupsCache = groupsCache;
        _moveHandler = moveHandler;
    }
    public override async Task OnConnectedAsync()
    {
        await Clients.Caller.SendAsync("ValidateConnection");
        await base.OnConnectedAsync();
    }

    [Authorize]
    public async Task ValidateConnection(string gameId, string connectionToken)
    {
        var getGameResult = await _gamesCache.GetGameAsync(gameId, out GameState gameState);
        if (!getGameResult.IsSuccess)
        {
            await abortConnection($"Не существует игры с id {gameId}");
        }
        Result isConnectionValid = GameConnectionValidator.Validate(gameState, connectionToken, Context.UserIdentifier!);
        if (!isConnectionValid.IsSuccess)
        {
            await abortConnection(isConnectionValid.Errors);
        }

        await _groupsCache.AddAsync(Context.ConnectionId, gameId);
        await _gamesCache.TryAddPlayer(gameId, Context.ConnectionId, Context.UserIdentifier!);
        await Clients.Group(gameId).SendAsync("PlayerJoined");

    }

    public async Task HandleMove(GameMove move)
    {
        string gameId = await _groupsCache.GetGroupId(Context.ConnectionId);
        Result gameExists = await _gamesCache.GetGameAsync(gameId, out GameState gameState);
        if (!gameExists.IsSuccess)
        {
            await abortConnection("Игра закрыта");
        }
        bool isMoveLegitimate = _moveHandler.HandleMove(gameState, move);
        if (!isMoveLegitimate)
        {
            await Clients.Caller.SendAsync("InvalidMove");
        }
        await _gamesCache.UpdateAsync(gameId, gameState);
        await Clients.OthersInGroup(gameId).SendAsync("ProcessMove", move);
        await Clients.Client(gameState.PlayerToMoveConnectionId).SendAsync("YourTurn");
    }

    private async Task abortConnection(object sendedErrorObject)
    {
        await Clients.Caller.SendAsync("Abort", sendedErrorObject);
        Context.Abort();
    }
}


