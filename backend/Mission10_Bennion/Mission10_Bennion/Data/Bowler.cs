using System.ComponentModel.DataAnnotations;

namespace Mission10_Bennion.Data
{
    // this class maps to the Bowlers table in the database
    public class Bowler
    {
        [Key] // primary key for the table
        public int BowlerID { get; set; }

        [Required]
        public string? BowlerLastName { get; set; }

        [Required]
        public string? BowlerFirstName { get; set; }

        // middle initial is optional, not everyone has one
        public string? BowlerMiddleInit { get; set; }
        public string? BowlerAddress { get; set; }
        public string? BowlerCity { get; set; }
        public string? BowlerState { get; set; }
        public string? BowlerZip { get; set; }
        public string? BowlerPhoneNumber { get; set; }
        public int? TeamID { get; set; }

        // navigation property - lets us access the related Team object directly
        public Team? Team { get; set; }
    }
}
