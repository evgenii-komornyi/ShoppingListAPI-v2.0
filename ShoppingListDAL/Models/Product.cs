namespace ShoppingListDAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public string? Description { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreationDate { get; set; }
        public Category Category { get; set; }
    }
}
