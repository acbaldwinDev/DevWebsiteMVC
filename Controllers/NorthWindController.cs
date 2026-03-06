using DevWebsiteMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevWebsiteMVC.Controllers;

public class NorthWindController : Controller
{
    private readonly NorthWindContext _context;

    public NorthWindController(NorthWindContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Products()
    {
        var products = await _context.Products
            .AsNoTracking()
            .OrderBy(p => p.ProductName)
            .Take(25)
            .ToListAsync();

        return View(products);
    }
}
