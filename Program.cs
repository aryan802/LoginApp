using Microsoft.EntityFrameworkCore;
using LoginApp.Data;
using Microsoft.AspNetCore.Authentication.Cookies; // 👈 Needed for cookie auth

var builder = WebApplication.CreateBuilder(args);

// Register EF Core DbContext with SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Add Razor Pages, Authentication, Authorization
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";      // Redirect to login if not authenticated
        options.AccessDeniedPath = "/AccessDenied"; // Optional
    });

builder.Services.AddAuthorization();
var app = builder.Build();

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseAuthentication(); // 👈 This must come before UseAuthorization
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

app.Run();
