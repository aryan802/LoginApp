using LoginApp.Data;
using LoginApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
            // No special initialization needed for GET
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == Username && u.Password == Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login.");
                return Page();
            }

            // Store user session, then redirect
            return RedirectToPage("/EducationalQualifications");
        }

    }
}



