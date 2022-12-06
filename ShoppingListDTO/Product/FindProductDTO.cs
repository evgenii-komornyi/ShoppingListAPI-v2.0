namespace ShoppingListDTO.Product
{
    public class FindProductDTO : BasicDTO<string>
    {
        public ProductByIdDTO? product { get; set; }
    }
}
