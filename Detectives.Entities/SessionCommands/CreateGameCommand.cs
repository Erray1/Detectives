namespace Detectives.Entities.SessionCommands
{
    public class CreateGameCommand
    {
        public string SessionId { get; set; }
        public string SessionName { get; set; }
        public int MaxPlayers { get; set; }
        public GameType GameType { get; set; }
    }
}
