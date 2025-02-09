using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Shopping.API.Data;
using Shopping.API.Models;

namespace Shopping.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProsuctContext _context;
    private readonly ILogger<ProductController> _logger;

    public ProductController(ProsuctContext context, ILogger<ProductController> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> Get()
    {
        return await _context.Products.Find(p => true).ToListAsync();
    }
}
