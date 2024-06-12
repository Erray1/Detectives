using Ardalis.Result;
using Detectives.Entities;
using Detectives.GameManagement.Domain.Services;

namespace Detectives.GameManagement.Application
{
    public class JoinGameService : IJoinGameService
    {
        private readonly JoinGameClient _client;
        public JoinGameService(JoinGameClient client)
        {
            _client = client;
        }
        public Task<Result<GameConnectionToken>> JoinGame(string gameId)
        {
            throw new NotImplementedException();
        }
    }
}
