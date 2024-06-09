namespace Detectives.GameService.Domain.Communication
{
    public class AddPlayerResult
    {
        public string ConnectionToken { get; init; }
        public AddPlayerResult(string connectionToken)
        {
            ConnectionToken = connectionToken;
        }
    }
}
