using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoginApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }                 // Primary key.

        [Required]
        public string Username { get; set; }        // Used to log in.

        [Required]
        public string FullName { get; set; }        // User's full name.

        [Required]
        public string Password { get; set; }        // Plain-text in this example.

        public string Place { get; set; }           // City or town.

        public string PhoneNumber { get; set; }     // For password reset.

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }   // For password reset check.

        public string Country { get; set; }         // Country name.

        // Navigation property: one user can have many qualifications
        public ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();
    }
}


