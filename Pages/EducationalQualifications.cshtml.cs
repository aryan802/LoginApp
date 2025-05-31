using LoginApp.Data;
using LoginApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LoginApp.Pages
{
    public class EducationalQualificationsModel : PageModel
    {
        private readonly AppDbContext _context;

        public EducationalQualificationsModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Qualification Qualification { get; set; }

        public List<Qualification> Qualifications { get; set; }

        public IActionResult OnGet()
        {
            // Ensure user is logged in by checking session
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToPage("Login");
            }

            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return RedirectToPage("Login");
            }

            Qualifications = _context.Qualifications
                .Where(q => q.UserId == user.Id)
                .ToList();

            return Page();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var username = HttpContext.Session.GetString("Username");
            var user = await _context.Users
                .Include(u => u.Qualifications)
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
                return RedirectToPage("/Login");

            Qualifications = user.Qualifications.ToList();
            return Page();
        }

    }
}

