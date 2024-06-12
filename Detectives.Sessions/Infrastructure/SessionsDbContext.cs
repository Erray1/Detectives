using Detectives.Sessions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Detectives.Sessions.Infrastructure;
public class GameSessionsDbContext : DbContext
{
    public GameSessionsDbContext() { }
    public GameSessionsDbContext(DbContextOptions options) : base(options) { }
    public DbSet<GameSession> Sessions { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseNpgsql("");
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<GameSession>()
            .HasKey(e => e.Id);
    }
}

