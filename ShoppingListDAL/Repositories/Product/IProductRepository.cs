using Models;
using Models.Requests;

namespace ShoppingListDAL.Repositories
{
    public interface IProductRepository
    {
        Product Create(Product product);
        List<Product> ReadAll();
        Product? ReadSingle(ProductFindRequest request);
    }
}
