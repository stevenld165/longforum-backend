using longforum_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace longforum_backend.Data;

public class LongforumDbContext(DbContextOptions<LongforumDbContext> options) : DbContext(options)
{
    public DbSet<Video> Videos { get; set; } = null!;
    public DbSet<Creator> Creators { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Video>().HasData(
            new Video {
            Title = "The Spectacular Failure of the Star Wars Hotel",
            Creator = new Creator { Id = 1, Name = "Jenny Nicholson" },
            Link = "https://www.youtube.com/watch?v=T0CpOYZZZW4",
            Thumbnail = "https://i.ytimg.com/vi/T0CpOYZZZW4/hq720.jpg?sqp=-oaymwEnCNAFEJQDSFryq4qpAxkIARUAAIhCGAHYAQHiAQoIGBACGAY4AUAB&rs=AOn4CLCT33gkbK7okjm0feErdOSgo-c6QQ",
            Duration = 14735
            },
            new Video {
                Title = "we need more political superheroes",
                Creator = new Creator { Id = 2, Name = "Making Media Matter" },
                Link = "https://www.youtube.com/watch?v=jXy8sP0Dsgs",
                Thumbnail = "https://i.ytimg.com/vi/jXy8sP0Dsgs/hq720.jpg?sqp=-oaymwEnCNAFEJQDSFryq4qpAxkIARUAAIhCGAHYAQHiAQoIGBACGAY4AUAB&rs=AOn4CLBkfdZkxZZi552iTWHHsMstZ6XyGw",
                Duration = 1183
            });
        
        modelBuilder.Entity<User>().HasData(
        new User {
            Id = 1,
            Username = "steven",
            DisplayName = "STEVENNNNN!!! hehe",
            Bio = "I love video essays or whatever. This is a really long text with lots of stuff to test when I have a lot of stuff yes",
            Following = null,
            Reviews = null
        },
        new User
        {
            Id = 2,
            Username = "johnsmith",
            DisplayName = "John Smith",
            Bio = "Time is just a wibby wobbly timey wimey ball of... stuff? Yeah",
            Following = null,
            Reviews = null  
        });
    }
}