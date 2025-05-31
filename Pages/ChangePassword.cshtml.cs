using LoginApp.Data;
using LoginApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginApp.Pages
{
    public class ChangePasswordModel : PageModel
    {
        private readonly AppDbContext _context;

        public ChangePasswordModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string PhoneNumber { get; set; }

        [BindProperty]
        public DateTime DateOfBirth { get; set; }

        [BindProperty]
        public string NewPassword { get; set; }

        public void OnGet()
        {
            // Nothing to load on GET
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Verify identity by matching username, phone, and date of birth
            var user = _context.Users.FirstOrDefault(u =>
                u.Username == Username &&
                u.PhoneNumber == PhoneNumber &&
                u.DateOfBirth == DateOfBirth);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Verification failed. Check your details.");
                return Page();
            }

            // Update the password
            user.Password = NewPassword;
            _context.SaveChanges();

            return RedirectToPage("Login");
        }
    }
}


