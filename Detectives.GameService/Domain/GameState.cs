using Detectives.GameService.Domain.Communication;
using Detectives.GameService.Domain.Services;

namespace Detectives.GameService.Domain
{
    public class GameState
    {
        public static GameState Default(GameType gameType)
        {
            
        }
        public static GameState FromRequest(CreateGameRequest request)
        {
            return new GameState()
            {
                GameType = request.GameType,
                MaxPlayers = request.MaxPlayers,
                Name = request.GameName is not null ? request.GameName
                : "Придумай_имя"
            };
        }
        public string Name { get; set; }
        public GameType GameType { get; set; }
        public List<GameConnection> ConnectedUsers { get; set; } = new();
        public List<GamePendingConnection> PendingUsers { get; set; } = new();
        public bool IsOpen { get; set; } = true;
        public int MaxPlayers { get; set; }
        public int CurrentPlayers => ConnectedUsers.Count;
    }
}
