using LoginApp.Data;
using LoginApp.Models;
using Microsoft.AspNetCore.Mvc;
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

        public List<User> Users { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Users = await _context.Users
                .Include(u => u.Qualifications)
                .ToListAsync();

            return Page();
        }

    }
}



