using Ardalis.Result;
using Detectives.Entities;
using Detectives.GameManagement.Domain.Dto;

namespace Detectives.GameManagement.Domain.Services
{
    public interface ICreateGameService
    {
        public Task<Result<GameId>> CreateGame(CreateGameRequest request);
    }
}
