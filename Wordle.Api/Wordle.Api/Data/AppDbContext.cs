﻿using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection.Metadata;

namespace Wordle.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Word> Words => Set<Word>();
        public DbSet<Card> Cards => Set<Card>();
        public DbSet<DateWord> DateWords => Set<DateWord>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
                .Entity<DateWord>()
                .HasIndex(f => f.Date)
                .IsUnique();

        }
    }
}
