using Models;
using ShoppingListDAL.Data;

namespace ShoppingListDAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly ShoppingListContext _context;

        public CategoryRepository(ShoppingListContext context)
        {
            _context = context;
        }

        public List<Category> ReadAll()
        {
            return _context.Categories.OrderBy(category => category.Name).ToList();
        }
    }
}
