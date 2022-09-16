using Microsoft.AspNetCore.Mvc;
using ShoppingListDAL.Models;

namespace ShoppingListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
       private readonly ShoppingListContext _context;

        public ProductController(ShoppingListContext context)
        {
            _context = context;
        }

        [HttpGet("products")]
        public List<Product> GetProducts()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }
    }
}
