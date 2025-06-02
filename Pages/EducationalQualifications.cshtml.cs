using LoginApp.Data;
using LoginApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

        // Keep only the async GET handler:
        public async Task<IActionResult> OnGetAsync()
        {
            // Ensure user is logged in
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToPage("/Login");
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                return RedirectToPage("/Login");
            }

            Qualifications = await _context.Qualifications
                .Where(q => q.UserId == user.Id)
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToPage("/Login");
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                return RedirectToPage("/Login");
            }

            //if (!ModelState.IsValid)
            //{
            //    Qualifications = await _context.Qualifications
            //        .Where(q => q.UserId == user.Id)
            //        .ToListAsync();
            //    return Page();
            //}

            Qualification.UserId = user.Id;
            _context.Qualifications.Add(Qualification);
            await _context.SaveChangesAsync();

            return RedirectToPage(); // reload GET
        }
    }
}


