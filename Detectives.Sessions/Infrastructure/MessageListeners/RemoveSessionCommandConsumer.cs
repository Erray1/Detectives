using Detectives.Entities.SessionCommands;
using Detectives.Sessions.Application;
using MassTransit;

namespace Detectives.Sessions.Infrastructure.MessageListeners
{
    public class RemoveSessionCommandConsumer : IConsumer<RemoveSessionCommand>
    {
        private readonly SessionsManager _sessionsManager;
        private readonly ILogger<RemoveSessionCommandConsumer> _logger;
        public RemoveSessionCommandConsumer(
            SessionsManager sessionsManager,
            ILogger<RemoveSessionCommandConsumer> logger)
        {
            _logger = logger;
            _sessionsManager = sessionsManager;
        }
        public async Task Consume(ConsumeContext<RemoveSessionCommand> context)
        {
            bool success = await _sessionsManager.Remove(context.Message);
            if (!success)
            {
                _logger.LogError($"Невозможно удалить сессию с id {context.Message.SessionId}");
                var errorMessage = new ErrorAtProceedingCommandMessage()
                {
                    ErrorType = ErrorMessageType.Remove,
                    Message = "Не удалось удалить сессию"
                };
                await context.RespondAsync(errorMessage);
            }
        }
    }
}
