using Detectives.Entities.SessionCommands;
using Detectives.Sessions.Application;
using MassTransit;

namespace Detectives.Sessions.Infrastructure.MessageListeners
{
    public class AddSessionsCommandConsumer : IConsumer<CreateGameCommand>
    {
        private readonly SessionsManager _sessionsManager;
        private readonly ILogger<AddSessionsCommandConsumer> _logger;
        public AddSessionsCommandConsumer(
            SessionsManager sessionsManager,
            ILogger<AddSessionsCommandConsumer> logger)
        {
            _logger = logger;
            _sessionsManager = sessionsManager;
        }
        public async Task Consume(ConsumeContext<CreateGameCommand> context)
        {
            bool success = await _sessionsManager.Add(context.Message);
            if (!success)
            {
                _logger.LogError("Невозможно добавить новую сессию");
                var errorMessage = new ErrorAtProceedingCommandMessage()
                {
                    ErrorType = ErrorMessageType.Add,
                    Message = "Не удалось добавить сессию"
                };
                await context.RespondAsync(errorMessage);
            }
        }
    }
}
