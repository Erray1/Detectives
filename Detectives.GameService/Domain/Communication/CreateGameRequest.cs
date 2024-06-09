using System.ComponentModel.DataAnnotations;

namespace Detectives.GameService.Domain.Communication;
public class CreateGameRequest
{
    public string? GameName { get; set; }
    public string? GameId { get; set; }

    [Range(2, 8, ErrorMessage = $"Количество игроков должно быть в отрезке от 2 до 8")]
    public int MaxPlayers { get; set; }
    public GameType GameType { get; set; }
    
}

