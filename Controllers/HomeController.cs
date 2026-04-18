using Microsoft.AspNetCore.Mvc;
using ECommerceMVC.Data;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(string search)
    {
        var listings = _context.Listings.AsQueryable();

        // 🔥 Search logic
        if (!string.IsNullOrEmpty(search))
        {
            listings = listings.Where(l => l.Title.Contains(search));
        }

        return View(listings.ToList());
    }
}