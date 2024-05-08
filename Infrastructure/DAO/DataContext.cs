using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAO;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Election> Elections { get; set; }
    public DbSet<Voter> Voters { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Voter>()
            .HasKey(c => c.Id);
        
        modelBuilder.Entity<Election>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<User>()
            .HasKey(c => c.Id);
    }
}