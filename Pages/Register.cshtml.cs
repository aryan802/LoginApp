using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LoginApp.Models;
using LoginApp.Data;
using System.Threading.Tasks;

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
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Check if the username already exists
            var existingUser = await _context.Users.FindAsync(User.Username);
            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "Username already exists.");
                return Page();
            }

            // Save the new user
            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            // Redirect to the Login page after successful registration
            return RedirectToPage("/Login");
        }
    }
}



