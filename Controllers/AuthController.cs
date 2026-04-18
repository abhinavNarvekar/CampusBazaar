using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ECommerceMVC.Models;

public class AuthController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthController(UserManager<ApplicationUser> userManager,
                          SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // 🔹 GET: /Auth/Register
    public IActionResult Register()
    {
        return View();
    }

    // 🔹 POST: /Auth/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(
        string fullname,
        string username,
        string email,
        string password,
        string phone,
        string department,
         YearType year)
    {
        // ✅ Basic validation
        if (string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(username) ||
            string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
            string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(department) || year <= 0)
        {
            ViewBag.Error = "All fields are required";
            return View();
        }

        var user = new ApplicationUser
        {
            FullName = fullname,
            UserName = username,
            Email = email,
            PhoneNumber = phone,
            Department = department,   // 🔥 NEW
            Year = year                // 🔥 NEW
        };

       var result = await _userManager.CreateAsync(user, password);

if (result.Succeeded)
{
    return RedirectToAction("Login");
}

foreach (var error in result.Errors)
{
    Console.WriteLine(error.Description); // 🔥 IMPORTANT
    ModelState.AddModelError("", error.Description);
}

return View();
    }

    // 🔹 GET: /Auth/Login
    public IActionResult Login()
    {
        return View();
    }

    // 🔹 POST: /Auth/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ViewBag.Error = "All fields are required";
            return View();
        }

        var result = await _signInManager.PasswordSignInAsync(
            username, password, false, false);

        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Invalid username or password";
        return View();
    }

    // 🔹 GET: /Auth/Logout
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction("Login", "Auth");
    }
}