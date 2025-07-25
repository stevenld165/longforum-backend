﻿using longforum_backend.Models;
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
    }
}