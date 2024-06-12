using Detectives.Sessions.Application.Mapping;
using Detectives.Sessions.Domain.Entities;
using Detectives.Sessions.Domain.Services;
using Detectives.Sessions.Infrastructure;

namespace Detectives.Sessions.Application.UserServices
{
    public class SessionsRepository : ISessionsRepository
    {
        private readonly GameSessionsDbContext _dbContext;
        public SessionsRepository(GameSessionsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<GameSession>> GetSessionsPagedAsync(int pageSize, int currentPage)
        {
           return _dbContext.Sessions.PageAsync(pageSize, currentPage);
        }
    }
}
