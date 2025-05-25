using LoginApp.Data;
using LoginApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class UpdateProfileModel : PageModel
{
    private readonly AppDbContext _context;

    public UpdateProfileModel(AppDbContext context) => _context = context;

    [BindProperty]
    public User User { get; set; }

    public IActionResult OnGet()
    {
        var username = TempData["Username"] as string;
        if (username == null) return RedirectToPage("Login");

        User = _context.Users.FirstOrDefault(u => u.Username == username);
        return Page();
    }

    public IActionResult OnPost()
    {
        _context.Users.Update(User);
        _context.SaveChanges();
        return RedirectToPage("UsersList");
    }
}

