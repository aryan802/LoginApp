using LoginApp.Data;
using LoginApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class UsersListModel : PageModel
{
    private readonly AppDbContext _context;
    public List<User> Users { get; set; }

    public UsersListModel(AppDbContext context) => _context = context;

    public void OnGet()
    {
        Users = _context.Users.ToList();
    }
}

