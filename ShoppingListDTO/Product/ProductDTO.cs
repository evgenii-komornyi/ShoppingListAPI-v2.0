using Models.Errors;

namespace ShoppingListDTO.Product
{
    public class ProductDTO : BasicDTO<string>
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? category { get; set; }
        public int category_id { get; set; }
        public decimal price { get; set; }
        public string? description { get; set; }
    }
}
