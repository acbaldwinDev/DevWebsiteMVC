using Microsoft.AspNetCore.Mvc;

namespace DevWebsiteMVC.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { message = "API is running" });
    }
}


[ApiController]
[Route("api/[controller]")]
public class ProductApiController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new[]
        {
            new { id = 1, name = "Laptop", price = 1200 },
            new { id = 2, name = "Phone", price = 800 }
        });
    }
}

