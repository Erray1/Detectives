namespace Detectives.Sessions.Domain.Entities;
public class GameSession
{
    public string Id { get; set; }
    public string Type { get; set; }
    public string Name { get; set; } 
    public int NumberOfPlayers { get; set; } = 0;
    public int MaxPlayers { get; set; }
    public bool IsOpen { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

