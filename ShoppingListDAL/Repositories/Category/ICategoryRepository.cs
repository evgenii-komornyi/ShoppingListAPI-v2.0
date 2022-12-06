using Models;

namespace ShoppingListDAL.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> ReadAll();
    }
}
