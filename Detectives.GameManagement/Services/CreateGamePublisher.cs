using Detectives.Entities.SessionCommands;
using Detectives.GameManagement.Domain.Dto;
using MassTransit;

namespace Detectives.GameManagement.Services
{
    public class CreateGamePublisher
    {
        private readonly ILogger<CreateGamePublisher> _logger;
        private readonly IPublishEndpoint _endpoint;
        public CreateGamePublisher(
            ILogger<CreateGamePublisher> logger,
            IPublishEndpoint endpoint
            )
        {
            _endpoint = endpoint;
            _logger = logger;
        }

        public async Task Publish(CreateGameRequest request)
        {
            CreateGameCommand command = new CreateGameCommand()
            {
                GameType = request.GameType,
                MaxPlayers = request.MaxPlayers,
                SessionId = request.GameId,
                SessionName = request.GameName
            };
            await _endpoint.Publish(command);
        }
    }
}
