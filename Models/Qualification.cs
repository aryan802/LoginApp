using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginApp.Models
{
    public class Qualification
    {
        [Key]
        public int Id { get; set; }                    // Primary key.

        [Required]
        public string Degree { get; set; }             // E.g. "B.Sc. Computer Science".

        [Required]
        public string University { get; set; }         // E.g. "State University".

        [Required]
        public int Year { get; set; }                  // Year of completion.

        public string Grade { get; set; }              // E.g. "A+" or "3.8 GPA".

        // Foreign key to User:
        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }                 // Navigation back to User.
    }
}


