using Detectives.Entities.SessionCommands;
using Detectives.Sessions.Application;
using MassTransit;
using Microsoft.EntityFrameworkCore.Update;

namespace Detectives.Sessions.Infrastructure.MessageListeners
{
    public class ModifySessionCommandConsumer : IConsumer<ModifySessionCommand>
    {
        private readonly SessionsManager _sessionsManager;
        private readonly ILogger<ModifySessionCommandConsumer> _logger;
        public ModifySessionCommandConsumer(
            SessionsManager sessionsManager,
            ILogger<ModifySessionCommandConsumer> logger)
        {
            _logger = logger;
            _sessionsManager = sessionsManager;
        }
        public async Task Consume(ConsumeContext<ModifySessionCommand> context)
        {
            bool success = await _sessionsManager.Update(context.Message);
            if (!success)
            {
                _logger.LogError($"Невозможно изменить сессию с id {context.Message.SessionId}, операция: {context.Message.CommandType}");
                var errorMessage = new ErrorAtProceedingCommandMessage()
                {
                    ErrorType = ErrorMessageType.Modify,
                    Message = "Не удалось изменить сессию"
                };
                await context.RespondAsync(errorMessage);
            }
        }
    }
}
