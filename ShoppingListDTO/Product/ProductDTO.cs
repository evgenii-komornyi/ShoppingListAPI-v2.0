using ShoppingListDTO.FileStorage;

namespace ShoppingListDTO.Product
{
    public class ProductDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public string brand { get; set; }
        public string category { get; set; }
        public decimal price { get; set; }
        public bool isAvailable { get; set; }
        public bool inStock { get; set; }
        public ICollection<FileStorageDTO> files { get; set; }
    }
}
