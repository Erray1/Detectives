using Ardalis.Result;
using Detectives.Entities;
using Detectives.Entities.Dto;

namespace Detectives.GameManagement.Domain.Services
{
    public interface IJoinGameService
    {
        public Task<JoinGameResponse> JoinGame(GameId gameId);
    }
}
