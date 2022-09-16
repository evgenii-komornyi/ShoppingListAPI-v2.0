using Microsoft.AspNetCore.Mvc;
using ShoppingListDAL.Models;
using ShoppingListDAL.Models.Requests;
using ShoppingListDAL.Repositories;

namespace ShoppingListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
       private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("products")]
        public List<Product> GetProducts()
        {
            return _productRepository.ReadAll();
        }

        [HttpGet("products/product/{id}")]
        public Product? GetProductById(int id)
        {
            ProductFindRequest request = new ProductFindRequest
            {
                Id = id
            };

            return _productRepository.ReadSingle(request);
        }
    }
}
