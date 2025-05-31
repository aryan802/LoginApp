using LoginApp.Data;
using LoginApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginApp.Pages
{
    public class UpdateProfileModel : PageModel
    {
        private readonly AppDbContext _context;

        public UpdateProfileModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        public IActionResult OnGet()
        {
            // Read “Username” from session (set on login)
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToPage("Login"); // Not logged in
            }

            // Load the user from DB
            User = _context.Users.FirstOrDefault(u => u.Username == username);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Update the existing user row
            _context.Users.Update(User);
            _context.SaveChanges();

            // After saving, go to UsersList
            return RedirectToPage("UsersList");
        }
    }
}

