using Microsoft.EntityFrameworkCore;
using Models;
using Models.Requests;
using ShoppingListDAL.Data;

namespace ShoppingListDAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly ShoppingListContext _context;

        public ProductRepository(ShoppingListContext context)
        {
            _context = context;
        }

        public Product Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public List<Product> ReadAll() =>
            _context.Products
                .Include(product => product.Category)
                .Include(product => product.Files)
                .ToList();


        public Product? ReadSingle(ProductFindRequest request) =>
            _context.Products
                .Include(product => product.Category)
                .Include(product => product.Files)
                .FirstOrDefault(product => product.Id == request.Id);
    }
}
