using Detectives.GameService.GamesCache;

namespace Detectives.GameService.Services
{
    public class GameConnectionService
    {
        private readonly IGamesCacheService _gamesCache;
        public GameConnectionService(IGamesCacheService gamesCache)
        {
            _gamesCache = gamesCache;
        }
    }
}
