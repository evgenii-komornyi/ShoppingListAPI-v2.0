using ShoppingListDTO.FileStorage;

namespace ShoppingListDTO.Product
{
    public class ProductByIdDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public string brand { get; set; }
        public string category { get; set; }
        public int categoryId { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public DateTime creationDate { get; set; }
        public bool isAvailable { get; set; }
        public bool inStock { get; set; }
        public ICollection<FileStorageDTO> files { get; set; }
    }
}
