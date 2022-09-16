using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public string? Description { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual Category? Category { get; set; }

        /*[NotMapped]
        public string? CategoryName
        {
            get { return this.Category != default(Category) ? this.Category.Name : default(string); }
        }*/
    }
}
