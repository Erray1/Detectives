namespace Detectives.GameService.GamesCache
{
    public interface IGroupsCacheService
    {
        public string Get(string userConnectionId);
        public bool Add(string userConnectionId, string groupId);
        public bool Remove(string userConnectionID);
    }
}
