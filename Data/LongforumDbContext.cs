using longforum_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace longforum_backend.Data;

public class LongforumDbContext(DbContextOptions<LongforumDbContext> options) : DbContext(options)
{
    public DbSet<Video> Videos { get; set; } = null!;
    public DbSet<Creator> Creators { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<List> Lists { get; set; } = null!;
    public DbSet<ListEntry> ListEntries { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
    }
}