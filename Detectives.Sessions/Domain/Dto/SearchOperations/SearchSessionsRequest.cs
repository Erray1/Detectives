namespace Detectives.Sessions.Domain.Dto.SearchOperations
{
    public class SearchSessionsRequest
    {
        public string SearchQuery { get; set; }
        public List<SearchRule> Rules { get; set; } = new();
    }

}
