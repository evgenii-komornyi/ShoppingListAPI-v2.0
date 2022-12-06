using Models.Responses;
using ShoppingListDAL.Repositories;

namespace ShoppingListBLL.Services
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public CategoryFindResponse FindAll()
        {
            var response = new CategoryFindResponse();

            response.ListOfFoundCategories = _repository.ReadAll();

            return response;
        }
    }
}
