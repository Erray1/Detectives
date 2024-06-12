using Detectives.Sessions.Domain.Dto;
using Detectives.Sessions.Domain.Entities;

namespace Detectives.Sessions.Application.Mapping
{
    public static class SessionsMapping
    {
        public static List<GameSessionDto> ToDto(this List<GameSession> sessions)
        {
            return sessions
                .Select(x => new GameSessionDto
                {
                    CurrentPlayers = x.NumberOfPlayers,
                    IsOpen = x.IsOpen,
                    Name = x.Name,
                    MaxPlayers = x.MaxPlayers
                })
                .ToList();
        }
    }
}
