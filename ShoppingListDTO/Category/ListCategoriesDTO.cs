using ShoppingListDTO.Category;

namespace ShoppingListDTO
{
    public class ListCategoriesDTO : BasicDTO<string>
    {
        public List<CategoryDTO> categories { get; set; }
    }
}
