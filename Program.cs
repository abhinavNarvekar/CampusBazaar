using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ECommerceMVC.Data;
using ECommerceMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// 🔗 MySQL connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

// 🔐 Identity setup (passport equivalent)
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CloudinaryService>();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// ❌ Disable for now (you had warning)
/// app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // 🔥 IMPORTANT
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();