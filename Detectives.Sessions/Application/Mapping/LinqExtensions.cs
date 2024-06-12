using Microsoft.EntityFrameworkCore;

namespace Detectives.Sessions.Application.Mapping
{
    public static class LinqExtensions
    {
        public static async Task<List<T>> PageAsync<T>(this IQueryable<T> query, int page, int pageSize)
        {
            return await query
                .Skip(pageSize * page)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
