using System.ComponentModel.DataAnnotations;

namespace Mission10_Bennion.Data
{
    // maps to the Teams table - each bowler belongs to one of these teams
    public class Team
    {
        [Key]
        public int TeamID { get; set; }

        [Required]
        public string TeamName { get; set; } = string.Empty;

        // the captain is just another bowler's ID, not super important for this app
        public int? CaptainID { get; set; }
    }
}
