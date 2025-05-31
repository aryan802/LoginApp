using LoginApp.Data;
using LoginApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginApp.Pages
{
    public class EducationalQualificationsModel : PageModel
    {
        private readonly AppDbContext _context;

        public EducationalQualificationsModel(AppDbContext context)
        {
            _context = context;
        }

        // BindProperty for new qualification form
        [BindProperty]
        public Qualification Qualification { get; set; }

        // List of existing qualifications for the logged-in user
        public List<Qualification> Qualifications { get; set; }

        public IActionResult OnGet()
        {
            // 1. Ensure user is logged in by checking session
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                // Not logged in → redirect to Login
                return RedirectToPage("Login");
            }

            // 2. Find the User object from DB by username
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                // Somehow session is invalid—return to login
                return RedirectToPage("Login");
            }

            // 3. Load all qualifications for this user
            Qualifications = _context.Qualifications
                .Where(q => q.UserId == user.Id)
                .ToList();

            return Page();
        }

        public IActionResult OnPost()
        {
            // 1. Ensure user is still logged in
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToPage("Login");
            }

            // 2. Find the user entity
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return RedirectToPage("Login");
            }

            if (!ModelState.IsValid)
            {
                // If form fields (Degree, University, Year) are invalid
                // re-load existing qualifications so we can re-render the table
                Qualifications = _context.Qualifications
                    .Where(q => q.UserId == user.Id)
                    .ToList();
                return Page();
            }

            // 3. Assign the foreign key
            Qualification.UserId = user.Id;

            // 4. Add new qualification and save to DB
            _context.Qualifications.Add(Qualification);
            _context.SaveChanges();

            // 5. Redirect to GET so the page reloads with the updated list
            return RedirectToPage();
        }
    }
}
