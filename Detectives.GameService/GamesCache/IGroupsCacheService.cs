namespace Detectives.GameService.GamesCache
{
    public interface IGroupsCacheService
    {
        public Task<string> GetGroupId(string userConnectionId);
        public Task<bool> AddAsync(string userConnectionId, string groupId);
        public Task<bool> Remove(string userConnectionID);
    }
}
