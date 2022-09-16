using Microsoft.EntityFrameworkCore;
using Models;
using Models.Requests;
using ShoppingListDAL.Data;

namespace ShoppingListDAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingListContext _context;

        public ProductRepository(ShoppingListContext context)
        {
            _context = context;
        }

        public List<Product> ReadAll() =>
            _context.Products.Include(product => product.Category).ToList();


        public Product? ReadSingle(ProductFindRequest request) =>
            _context.Products
                .Include(product => product.Category)
                .FirstOrDefault(product => product.Id == request.Id);
    }
}
