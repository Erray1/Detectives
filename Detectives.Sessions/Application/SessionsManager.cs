using Detectives.Entities.SessionCommands;
using Detectives.Sessions.Domain.Entities;
using Detectives.Sessions.Infrastructure;

namespace Detectives.Sessions.Application
{
    public class SessionsManager
    {
        private readonly GameSessionsDbContext _dbContext;
        public SessionsManager(GameSessionsDbContext gameSessionsDbContext)
        {
            _dbContext = gameSessionsDbContext;
        }
        public async Task<bool> Add(CreateGameCommand command)
        {
            var existingSession = await _dbContext.Sessions.FindAsync(command.SessionId);
            if (existingSession != null)
            {
                return false;
            }
            GameSession session = new()
            {
                Id = command.SessionId,
                Name = command.SessionName,
                Type = command.GameType,
                MaxPlayers = command.MaxPlayers
            };
            _dbContext.Sessions.Add(session);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Remove(RemoveSessionCommand command)
        {
            var session = await _dbContext.Sessions.FindAsync(command.SessionId);
            if (session is null)
            {
                return false ;
            }
            _dbContext.Sessions.Remove(session);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update(ModifySessionCommand command)
        {
            var session = await _dbContext.Sessions.FindAsync(command.SessionId);
            if (session is null) { return false; }

            switch (command.CommandType)
            {
                case ModifySessionCommandType.AddPlayer:
                    session.NumberOfPlayers++;
                    break;
                case ModifySessionCommandType.RemovePlayer:
                    session.NumberOfPlayers--;
                    break;
                case ModifySessionCommandType.CloseSession:
                    session.IsOpen = false;
                    break;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
