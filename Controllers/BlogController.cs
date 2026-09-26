using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunEasy_Blog.Data;
using SunEasy_Blog.Models;

namespace DotNetBlog.Controllers;

public class BlogController : Controller
{
    private readonly BlogContext _context;

    public BlogController(BlogContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var posts = await _context.BlogPosts.OrderByDescending(p => p.CreatedAt).ToListAsync();
        return View(posts);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BlogPost post)
    {
        if (ModelState.IsValid)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(post);
    }
}