using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ECommerceMVC.Data;
using ECommerceMVC.Models;

public class ListingsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly CloudinaryService _cloudinary;

    public ListingsController(ApplicationDbContext context, CloudinaryService cloudinary)
    {
        _context = context;
        _cloudinary = cloudinary;
    }

    // 🔹 GET: Create
    [Authorize]
    public IActionResult Create()
    {
        return View();
    }

    // 🔹 POST: Create (WITH IMAGE UPLOAD)
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public IActionResult Create(Listing listing, IFormFile imageFile)
    {
        if (!ModelState.IsValid)
            return View(listing);

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
            return Unauthorized();

        // 🔥 Upload to Cloudinary
        if (imageFile != null && imageFile.Length > 0)
        {
            var imageUrl = _cloudinary.UploadImage(imageFile);
            listing.ImageUrl = imageUrl;
        }

        listing.UserId = userId;

        _context.Listings.Add(listing);
        _context.SaveChanges();

        return RedirectToAction("Index", "Home");
    }

    // 🔹 GET: Edit
    [Authorize]
    public IActionResult Edit(int id)
    {
        var listing = _context.Listings.FirstOrDefault(l => l.Id == id);

        if (listing == null)
            return NotFound();

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (listing.UserId != userId)
            return Unauthorized();

        return View(listing);
    }

    // 🔹 POST: Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public IActionResult Edit(int id, Listing updatedListing)
    {
        var listing = _context.Listings.FirstOrDefault(l => l.Id == id);

        if (listing == null)
            return NotFound();

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (listing.UserId != userId)
            return Unauthorized();

        // update only allowed fields
        listing.Title = updatedListing.Title;
        listing.Description = updatedListing.Description;
        listing.Price = updatedListing.Price;

        _context.SaveChanges();

        return RedirectToAction("Index", "Home");
    }

    // 🔹 POST: Delete
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public IActionResult Delete(int id)
    {
        var listing = _context.Listings.FirstOrDefault(l => l.Id == id);

        if (listing == null)
            return NotFound();

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null || listing.UserId != userId)
            return Unauthorized();

        _context.Listings.Remove(listing);
        _context.SaveChanges();

        return RedirectToAction("Index", "Home");
    }

    // 🔹 GET: Details
    public IActionResult Details(int id)
    {
        var listing = _context.Listings
            .Include(l => l.User)
            .FirstOrDefault(l => l.Id == id);

        if (listing == null)
            return NotFound();

        return View(listing);
    }
}