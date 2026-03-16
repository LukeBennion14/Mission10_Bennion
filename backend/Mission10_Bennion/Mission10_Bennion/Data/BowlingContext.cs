using Microsoft.EntityFrameworkCore;
using Mission10_Bennion.Models;

namespace Mission10_Bennion.Data
{
    public class BowlingContext : DbContext
    {
        public BowlingContext(DbContextOptions<BowlingContext> options) : base(options) { }

        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
