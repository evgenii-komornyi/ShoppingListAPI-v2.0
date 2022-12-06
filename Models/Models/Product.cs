using System.Text.Json.Serialization;

namespace Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsInStock { get; set; }
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<FileStorage> Files { get; set; }
    }
}
