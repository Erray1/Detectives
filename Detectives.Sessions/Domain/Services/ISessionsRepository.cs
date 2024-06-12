using Detectives.Sessions.Domain.Entities;

namespace Detectives.Sessions.Domain.Services;
public interface ISessionsRepository
{
    public Task<List<GameSession>> GetSessionsPagedAsync(int pageSize, int currentPage);
}

