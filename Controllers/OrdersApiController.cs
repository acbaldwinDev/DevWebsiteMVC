using DevWebsiteMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevWebsiteMVC.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersApiController : ControllerBase
{
    private readonly NorthWindContext _context;

    public OrdersApiController(NorthWindContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? customerId, [FromQuery] int take = 50)
    {
        var normalizedCustomerId = string.IsNullOrWhiteSpace(customerId)
            ? null
            : customerId.Trim().ToUpperInvariant();

        var cappedTake = Math.Clamp(take, 1, 200);

        var query = _context.Orders
            .AsNoTracking()
            .Include(o => o.Customer)
            .AsQueryable();

        if (!string.IsNullOrEmpty(normalizedCustomerId))
        {
            query = query.Where(o => o.CustomerID == normalizedCustomerId);
        }

        var results = await query
            .OrderByDescending(o => o.OrderDate)
            .ThenByDescending(o => o.OrderID)
            .Take(cappedTake)
            .Select(o => new
            {
                o.OrderID,
                o.CustomerID,
                CompanyName = o.Customer != null ? o.Customer.CompanyName : null,
                o.OrderDate,
                o.ShippedDate,
                o.Freight,
                o.ShipName,
                o.ShipCity,
                o.ShipCountry
            })
            .ToListAsync();

        return Ok(results);
    }
}
