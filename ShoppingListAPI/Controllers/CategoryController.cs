using Microsoft.AspNetCore.Mvc;
using Models;
using ShoppingListBLL.Services;
using ShoppingListDTO;
using ShoppingListDTO.Category;

namespace ShoppingListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("categories")]
        public ListCategoriesDTO GetCategories()
        {
            List<CategoryDTO> categoryDTOList = new List<CategoryDTO>();
            var categories = _categoryService.FindAll().ListOfFoundCategories;

            foreach (var category in categories)
            {
                categoryDTOList.Add(ConvertCategoryToDTO(category));
            };

            return new ListCategoriesDTO
            {
                categories = categoryDTOList,
                status = Status.Success
            };
        }

        private CategoryDTO ConvertCategoryToDTO(Category category) => 
            new CategoryDTO
            {
                id = category.Id,
                category = category.Name,
                description = category.Description
            };
        
    }
}
