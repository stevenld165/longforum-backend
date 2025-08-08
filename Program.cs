using System.Text.Json.Serialization;
using longforum_backend.Data;
using longforum_backend.Models;
using longforum_backend.Startup;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<LongforumDbContext>(opt => opt.UseSqlite("Data Source=longforum.dat", o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)).UseSeeding((context, _) =>
{
    context.Set<Creator>().AddRange(
        new Creator { Id = 1, Name = "Jenny Nicholson" },
        new Creator { Id = 2, Name = "Making Media Matter" },
        new Creator { Id = 3, Name = "Noralities" },
        new Creator { Id = 4, Name = "Noah Boulter" }
        );
    
    context.Set<Video>().AddRange(
        new Video {
            Id = 1,
            Title = "The Spectacular Failure of the Star Wars Hotel",
            CreatorId = 1,
            Link = "https://www.youtube.com/watch?v=T0CpOYZZZW4",
            Thumbnail = "https://i.ytimg.com/vi/T0CpOYZZZW4/hq720.jpg?sqp=-oaymwEnCNAFEJQDSFryq4qpAxkIARUAAIhCGAHYAQHiAQoIGBACGAY4AUAB&rs=AOn4CLCT33gkbK7okjm0feErdOSgo-c6QQ",
            Duration = 14735
        },
        new Video {
            Id = 2,
            Title = "we need more political superheroes",
            CreatorId = 2,
            Link = "https://www.youtube.com/watch?v=jXy8sP0Dsgs",
            Thumbnail = "https://i.ytimg.com/vi/jXy8sP0Dsgs/hq720.jpg?sqp=-oaymwEnCNAFEJQDSFryq4qpAxkIARUAAIhCGAHYAQHiAQoIGBACGAY4AUAB&rs=AOn4CLBkfdZkxZZi552iTWHHsMstZ6XyGw",
            Duration = 1183
        },
        new Video {
            Id = 3,
            Title = "Sleeping Beauty Deserves a Better Ending",
            CreatorId = 3,
            Link = "https://www.youtube.com/watch?v=xxy0ZtIFSlk",
            Thumbnail = "https://i.ytimg.com/vi/xxy0ZtIFSlk/hq720.jpg?sqp=-oaymwEnCNAFEJQDSFryq4qpAxkIARUAAIhCGAHYAQHiAQoIGBACGAY4AUAB&rs=AOn4CLA6Lqcnh9UNQA4gOnN9CNxRGLRKmw",
            Duration = 5173
        },new Video {
            Id = 4,
            Title = "WordGirl Could Beat Superman (and all of fiction)",
            CreatorId = 4,
            Link = "https://www.youtube.com/watch?v=qXJuLaXPYnQ",
            Thumbnail = "https://i.ytimg.com/vi/qXJuLaXPYnQ/hq720.jpg?sqp=-oaymwEnCNAFEJQDSFryq4qpAxkIARUAAIhCGAHYAQHiAQoIGBACGAY4AUAB&rs=AOn4CLC1SK7Zu97pWzmaDVGgkyOzhpIJkQ",
            Duration = 2258
        });
    
    context.Set<User>().AddRange(
        new User {
            Id = 1,
            Username = "steven",
            DisplayName = "STEVENNNNN!!! hehe",
            Bio = "I love video essays or whatever. This is a really long text with lots of stuff to test when I have a lot of stuff yes",
        },
        new User
        {
            Id = 2,
            Username = "johnsmith",
            DisplayName = "John Smith",
            ProfilePic = "https://i.pinimg.com/736x/50/75/c1/5075c1057eab4e9400eb46dccf4364b4.jpg",
            Bio = "Time is just a wibby wobbly timey wimey ball of... stuff? Yeah",
        });
    
    context.Set<Review>().AddRange(
        new Review {
            Id = 1,
            Burgers = 9,
            IsLiked = false,
            ReviewText = "This was a good use of 4 hours",
            UserId = 2,
            VideoId = 1
        },
        new Review {
            Id = 2,
            Burgers = 7,
            IsLiked = true,
            ReviewText = "cool video yay",
            UserId = 2,
            VideoId = 2
        },
        new Review {
            Id = 3,
            Burgers = 10,
            IsLiked = true,
            ReviewText = "super intriguing look through the evolution of sleeping beauty and great commentary on the nature of how all fairy tales are big games of telephone through time",
            UserId = 2,
            VideoId = 3
        },
        new Review {
            Id = 4,
            Burgers = 0,
            IsLiked = false,
            ReviewText = "horrible repetitive mess of a video. actually completely loses the rails at the end like bestie...",
            UserId = 2,
            VideoId = 4
        });

    context.SaveChanges();
}));

builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

/*using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LongforumDbContext>();
    context.Database.EnsureCreated();
}*/

app.Run();