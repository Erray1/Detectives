using Detectives.Entities;
using Detectives.Entities.Dto;
using Detectives.GameManagement.Domain.Dto;
using MassTransit;

namespace Detectives.GameManagement.Application
{
    public class JoinGameClient
    {
        private readonly ILogger<JoinGameClient> _logger;
        private readonly IPublishEndpoint _endpoint;
        private readonly IRequestClient<JoinGameRequest> _requestClient;
        public JoinGameClient(
            ILogger<JoinGameClient> logger,
            IPublishEndpoint endpoint
            )
        {
            _endpoint = endpoint;
            _logger = logger;
        }

        public async Task<JoinGameResponse> GetResponse(JoinGameRequest request)
        {
            var response = await _requestClient.GetResponse<JoinGameResponse>(request);
            if (!response.Message.IsSuccesful)
            {
                _logger.LogError("Не удалось присоединиться к игре");
            }
            return response.Message;
        }
    }
}
