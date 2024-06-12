using Detectives.Entities;
using Detectives.Entities.Dto;
using Detectives.Entities.SessionCommands;
using Detectives.GameManagement.Domain.Dto;
using MassTransit;

namespace Detectives.GameManagement.Application
{
    public class CreateGameClient
    {
        private readonly ILogger<CreateGameClient> _logger;
        private readonly IPublishEndpoint _endpoint;
        private readonly IRequestClient<CreateGameRequest> _requestClient;
        public CreateGameClient(
            ILogger<CreateGameClient> logger,
            IPublishEndpoint endpoint
            )
        {
            _endpoint = endpoint;
            _logger = logger;
        }

        public async Task<CreateGameResponse> GetResponse(CreateGameRequest request)
        {
            var response = await _requestClient.GetResponse<CreateGameResponse>(request);
            if (!response.Message.IsSuccesful)
            {
                _logger.LogError("Не удалось создать игру");
            }
            return response.Message;
        }
    }
}
