using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission10_Bennion.Data;

namespace Mission10_Bennion.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // this means the endpoint is at /api/bowlers
    public class BowlersController : ControllerBase
    {
        // injecting the database context so we can query the bowling database
        private readonly BowlingContext _context;

        public BowlersController(BowlingContext context)
        {
            _context = context;
        }

        // GET /api/bowlers - returns only bowlers on the Marlins or Sharks teams
        [HttpGet]
        public async Task<IEnumerable<object>> GetBowlers()
        {
            return await _context.Bowlers
                .Include(b => b.Team) // join the Teams table so we get the team name
                .Where(b => b.Team != null &&
                    (b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")) // only these two teams
                .Select(b => new
                {
                    // picking just the fields we actually need to send to the frontend
                    b.BowlerFirstName,
                    b.BowlerMiddleInit,
                    b.BowlerLastName,
                    TeamName = b.Team!.TeamName,
                    b.BowlerAddress,
                    b.BowlerCity,
                    b.BowlerState,
                    b.BowlerZip,
                    b.BowlerPhoneNumber
                })
                .ToListAsync();
        }
    }
}
