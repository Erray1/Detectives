using Ardalis.Result;
using Detectives.Entities;
using Detectives.GameManagement.Domain.Dto;
using Detectives.GameManagement.Domain.Services;

namespace Detectives.GameManagement.Application
{
    public class CreateGameService : ICreateGameService
    {
        private readonly CreateGameClient _client;
        public CreateGameService(CreateGameClient publisher)
        {
            _client = publisher;
        }
        public async Task<Result<GameId>> CreateGame(CreateGameRequest request)
        {
            var response = await _client.GetResponse(request);
            
            if (!response.IsSuccesful)
            {
                return Result.Error("Невозможно создать игру");
            }
            return Result.Success(response.GameId);
        }
    }
}
