namespace ShoppingListDTO.Product
{
    public class ListProductsDTO : BasicDTO<string>
    {
        public List<ProductDTO>? products { get; set; }
    }
}
