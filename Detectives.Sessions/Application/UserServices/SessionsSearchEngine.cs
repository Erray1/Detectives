using Detectives.Sessions.Domain.Dto.SearchOperations;
using Detectives.Sessions.Domain.Entities;
using Detectives.Sessions.Domain.Services;
using Detectives.Sessions.Infrastructure;
using System.Linq.Expressions;

namespace Detectives.Sessions.Application.UserServices
{
    public class SessionsSearchEngine : ISessionsSearchEngine
    {
        private readonly GameSessionsDbContext _dbContext;
        public SessionsSearchEngine(GameSessionsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<GameSession> Search(SearchSessionsRequest request)
        {
            var filtersExpression = getFiltersExpression(request);
            return _dbContext.Sessions
                .Where(filtersExpression)
                .Where(x => x.Name.Contains(request.SearchQuery))
                .OrderBy(x => x.Name.Length);

        }

        private Expression<Func<GameSession, bool>> getFiltersExpression(SearchSessionsRequest request)
        {
            (bool rulesAreValid, string? errorMessage) = validateRules(request.Rules);
            if (!rulesAreValid )
            {
                throw new InvalidOperationException(errorMessage);
            }

            var parameter = Expression.Parameter(typeof(GameSession));
            BinaryExpression expression = null!;
            foreach (var rule in request.Rules)
            {
                var prop = Expression.Property(parameter, rule.PropertyName);
                var val = Expression.Constant(rule.Value);
                var newExpression = Expression.MakeBinary(rule.Operation, prop, val);

                expression = expression is null ?
                    newExpression :
                    Expression.MakeBinary(ExpressionType.AndAlso, expression, newExpression);
            } 
                    # warning Не уверен, нужно ли здесь передавать parameter
            var cookedExpression = Expression.Lambda<Func<GameSession, bool>>(expression, parameter);
            return cookedExpression;
        }

        private (bool, string?) validateRules(List<SearchRule> rules)
        {
            throw new NotImplementedException();
        }
    }
}
