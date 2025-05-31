using LoginApp.Data;
using LoginApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LoginApp.Pages
{
    public class UsersListModel : PageModel
    {
        private readonly AppDbContext _context;

        public UsersListModel(AppDbContext context)
        {
            _context = context;
        }

        // This will hold all User entities, each with a list of Qualifications
        public List<User> Users { get; set; }

        public void OnGet()
        {
            // Eagerly load Qualifications so we can display them in the table
            Users = _context.Users
                .Include(u => u.Qualifications)
                .ToList();
        }
    }
}


