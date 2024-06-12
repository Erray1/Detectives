using Detectives.Sessions.Domain.Dto.SearchOperations;
using Detectives.Sessions.Domain.Entities;

namespace Detectives.Sessions.Domain.Services
{
    public interface ISessionsSearchEngine
    {
        public IQueryable<GameSession> Search(SearchSessionsRequest request);
    }
}
