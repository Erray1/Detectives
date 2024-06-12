namespace Detectives.Sessions.Domain.Dto
{
    public class GameSessionDto
    {
        public string Name { get; set; }
        public int CurrentPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public bool IsOpen { get; set; }
        public string JoinLink { get; set; }
    }
}
