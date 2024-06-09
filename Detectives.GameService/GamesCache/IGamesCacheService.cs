using Ardalis.Result;
using Detectives.GameService.Domain;
using Detectives.GameService.Domain.Communication;

namespace Detectives.GameService.GamesCache
{
    public interface IGamesCacheService
    {
        bool GetGame(string gameId, out GameState gameState);
        bool OpenGame(GameState game);
        void CloseGame(string gameId);
        Result<AddPlayerResult> TryAddPlayer(string gameId, string playerConnectionId);
        Result TryRemovePlayer(string gameId, string playerConnectionId);
        
    }
}
