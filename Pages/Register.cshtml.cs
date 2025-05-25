using LoginApp.Data;
using LoginApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class RegisterModel : PageModel
{
    private readonly AppDbContext _context;

    public RegisterModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public User User { get; set; }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        _context.Users.Add(User);
        _context.SaveChanges();
        return RedirectToPage("Login");
    }
}
