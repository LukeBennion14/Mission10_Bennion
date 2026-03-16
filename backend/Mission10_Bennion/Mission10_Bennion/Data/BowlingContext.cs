using Microsoft.EntityFrameworkCore;

namespace Mission10_Bennion.Data
{
    // the DbContext is basically our connection to the database - everything goes through here
    public class BowlingContext : DbContext
    {
        public BowlingContext(DbContextOptions<BowlingContext> options) : base(options) { }

        // these represent the tables we care about in the database
        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
