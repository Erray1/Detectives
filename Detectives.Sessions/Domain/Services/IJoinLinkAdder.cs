using Detectives.Sessions.Domain.Dto;

namespace Detectives.Sessions.Domain.Services
{
    public interface IJoinLinkAdder
    {
        public void AddJoinLinks(List<GameSessionDto> sessionDtos);
    }
}
