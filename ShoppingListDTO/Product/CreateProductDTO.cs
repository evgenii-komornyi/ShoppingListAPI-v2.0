using Models.Responses;

namespace ShoppingListDTO.Product
{
    public class CreateProductDTO : BasicDTO<string>
    {
        public ProductCreateResponse? newProduct { get; set; }
    }
}
