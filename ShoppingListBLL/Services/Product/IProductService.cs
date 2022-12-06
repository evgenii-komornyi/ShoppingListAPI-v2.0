using Models.Requests;
using Models.Responses;

namespace ShoppingListBLL.Services
{
    public interface IProductService
    {
        ProductCreateResponse CreateProduct(ProductCreateRequest request);
        ProductFindResponse FindAll();
        ProductFindResponse FindById(ProductFindRequest request);
    }
}
