using LoginApp.Data;
using LoginApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> OnGetAsync()
        {
            var username = HttpContext.Session.GetString("Username");
            if (username == null)
                return RedirectToPage("/Login");

            User = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Users.Update(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("/EducationalQualifications");
        }

    }
}


