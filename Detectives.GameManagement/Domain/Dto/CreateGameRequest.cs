using Detectives.Entities;
using System.ComponentModel.DataAnnotations;

namespace Detectives.GameManagement.Domain.Dto;
public class CreateGameRequest
{
    [Required]
    public string GameName { get; set; }
    public string GameId { get; set; } = Guid.NewGuid().ToString();

    [Range(2, 8, ErrorMessage = $"Количество игроков должно быть в отрезке от 2 до 8")]
    public int MaxPlayers { get; set; }
    public GameType GameType { get; set; }
    
}

