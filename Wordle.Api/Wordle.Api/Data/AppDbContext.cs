using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection.Metadata;

namespace Wordle.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Card> Cards => Set<Card>();

    }
}
