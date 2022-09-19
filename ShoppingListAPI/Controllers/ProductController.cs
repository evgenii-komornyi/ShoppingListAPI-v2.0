using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Requests;
using ShoppingListBLL.Services;
using ShoppingListDTO.Product;

namespace ShoppingListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        readonly IProductService _productService;
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        public ListProductsDTO GetProducts()
        {
            var productDTOList = new List<ProductDTO>();
            var productList = _productService.FindAll().ListOfFoundProducts;

            foreach (var product in productList)
            {
                productDTOList.Add(СonvertProductToDTO(product));
            }

            return new ListProductsDTO
            {
                products = productDTOList
            };
        }

        [HttpGet("products/product/{id}")]
        public FindProductDTO? GetProductById(int id)
        {
            return new FindProductDTO
            {
                product = СonvertProductToDTO(_productService.FindById(new ProductFindRequest
                {
                    Id = id
                }).FoundProduct)
            };
        }

        private ProductDTO СonvertProductToDTO(Product product)
        {
            var errors = new List<string>();

            if (product == null)
            {
                errors.Add("Product not Found");
                return new ProductDTO
                {
                    validationErrors = errors
                };
            }
            else
            {
                return new ProductDTO
                {
                    id = product.Id,
                    name = product.Name,
                    category = product.Category.Name,
                    category_id = product.Category.Id,
                    price = product.Price,
                    description = product.Description,
                };
            }
        }
    }
}
