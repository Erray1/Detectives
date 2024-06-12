using System.Linq.Expressions;

namespace Detectives.Sessions.Domain.Dto.SearchOperations
{
    public class SearchRule
    {
        public string PropertyName { get; set; }
        public ExpressionType Operation { get; set; }
        public object Value { get; set; }
    }
}
