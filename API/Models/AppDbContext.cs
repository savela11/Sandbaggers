using API.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();

    public DbSet<UserSettings> UserSettings => Set<UserSettings>();
    // public DbSet<Course> Courses { get; set; }
    // public DbSet<Round> Rounds { get; set; }
    // public DbSet<Event> Events { get; set; }
    // public DbSet<EventResults> EventResults { get; set; }
    // public DbSet<Gallery> Galleries { get; set; }
    // public DbSet<PowerRanking> PowerRankings { get; set; }
    // public DbSet<Draft> Drafts { get; set; }
    // public DbSet<Team> Teams { get; set; }
    public DbSet<Bet> Bets { get; set; }
    // public DbSet<Idea> Ideas { get; set; }
}