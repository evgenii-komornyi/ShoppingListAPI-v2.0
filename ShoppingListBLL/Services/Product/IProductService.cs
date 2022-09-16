using Models.Requests;
using Models.Responses;

namespace ShoppingListBLL.Services
{
    public interface IProductService
    {
        ProductFindResponse FindAll();
        ProductFindResponse FindById(ProductFindRequest request);
    }
}
