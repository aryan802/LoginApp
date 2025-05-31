using LoginApp.Data;
using LoginApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginApp.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly AppDbContext _context;

        public RegisterModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {
            // No initialization needed on GET
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // If any [Required] fields are missing or invalid, re-display form with errors
                return Page();
            }

            // Add the new user to the database
            _context.Users.Add(User);
            _context.SaveChanges();

            // Redirect to Login after successful registration
            return RedirectToPage("Login");
        }
    }
}

