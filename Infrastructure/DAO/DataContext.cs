using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAO;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Voting> Votings { get; set; }
    public DbSet<Ballot> BallotOptions { get; set; }
    public DbSet<Vote> Votes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // здесь можно настроить конфигурации для сущностей или их отношений, если это необходимо
    }
}