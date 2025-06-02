using LoginApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1️ Add Razor Pages services:
builder.Services.AddRazorPages();

// 2️ Add EF Core with SQLite:
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 3️⃣ Add Session services (so we can store “Username” after login):
builder.Services.AddSession();

var app = builder.Build();

// ── Middleware Pipeline ────────────────────────────────────────────────────────────

// Serve static files (CSS, JS, images) from wwwroot/
app.UseStaticFiles();

// Enable routing
app.UseRouting();

// Enable session (must come before MapRazorPages if you want to read/write session in page handlers)
app.UseSession();

// Map Razor Pages (*.cshtml) to endpoints
app.MapRazorPages();




// Run the application
app.Run();
