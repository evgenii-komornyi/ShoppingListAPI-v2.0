using Models;
using Models.Requests;

namespace ShoppingListDAL.Repositories
{
    public interface IProductRepository
    {
        List<Product> ReadAll();
        Product? ReadSingle(ProductFindRequest request);
    }
}
