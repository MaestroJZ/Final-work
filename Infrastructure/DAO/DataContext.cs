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
    public DbSet<Vote> Votes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Voter>()
            .HasKey(c => c.Id);
        
        modelBuilder.Entity<Election>()
            .HasKey(c => c.Id);
        
        modelBuilder.Entity<Transaction>()
            .HasKey(c => c.Id);
        
        modelBuilder.Entity<Candidate>()
            .HasOne(c => c.Election)
            .WithMany(e => e.Candidates)
            .HasForeignKey(c => c.ElectionId);
        
        modelBuilder.Entity<Transaction>()
            .HasOne(c => c.Candidate)
            .WithMany(e => e.Transactions)
            .HasForeignKey(c => c.CandidateId);
        
        modelBuilder.Entity<Vote>()
            .HasKey(c => c.Id);
        
        modelBuilder.Entity<Vote>()
            .HasOne(v => v.Voter)
            .WithMany()
            .HasForeignKey(v => v.VoterId);

        modelBuilder.Entity<Vote>()
            .HasOne(v => v.Election)
            .WithMany()
            .HasForeignKey(v => v.ElectionId);
    }
}