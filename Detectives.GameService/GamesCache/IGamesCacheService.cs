using Ardalis.Result;
using Detectives.GameService.Domain;
using Detectives.GameService.Domain.Communication;

namespace Detectives.GameService.GamesCache
{
    public interface IGamesCacheService
    {
        Task UpdateAsync(string gameId, GameState gameState);
        Task<Result> GetGameAsync(string gameId, out GameState gameState);
        Result OpenGame(GameState game);
        Result CloseGame(string gameId);
        Task<AddPlayerResult> TryAddPlayer(string gameId, string playerConnectionId, string userId);
        Result TryRemovePlayer(string gameId, string playerConnectionId);
        
    }
}
