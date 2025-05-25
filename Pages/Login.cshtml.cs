using LoginApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LoginModel : PageModel
{
    private readonly AppDbContext _context;
    public LoginModel(AppDbContext context) => _context = context;

    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public IActionResult OnPost()
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);
        if (user == null) return Page();

        TempData["Username"] = Username;
        return RedirectToPage("UpdateProfile");
    }
}

