using LoginApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ChangePasswordModel : PageModel
{
    private readonly AppDbContext _context;
    public ChangePasswordModel(AppDbContext context) => _context = context;

    [BindProperty] public string Username { get; set; }
    [BindProperty] public string PhoneNumber { get; set; }
    [BindProperty] public DateTime DateOfBirth { get; set; }
    [BindProperty] public string NewPassword { get; set; }

    public IActionResult OnPost()
    {
        var user = _context.Users.FirstOrDefault(u =>
            u.Username == Username && u.PhoneNumber == PhoneNumber && u.DateOfBirth == DateOfBirth);

        if (user == null) return Page();

        user.Password = NewPassword;
        _context.SaveChanges();
        return RedirectToPage("Login");
    }
}

