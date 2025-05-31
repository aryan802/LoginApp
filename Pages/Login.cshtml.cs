using LoginApp.Data;
using LoginApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;

        public LoginModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
            // No initialization needed on GET
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Attempt to find a matching user
            var user = _context.Users
                .FirstOrDefault(u => u.Username == Username && u.Password == Password);

            if (user == null)
            {
                // Invalid credentials—re-display login form
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return Page();
            }

            // Successful login:
            // Store the username in session so other pages know who’s logged in
            HttpContext.Session.SetString("Username", Username);

            // Redirect to EducationalQualifications page right after login
            return RedirectToPage("EducationalQualifications");
        }
    }
}


