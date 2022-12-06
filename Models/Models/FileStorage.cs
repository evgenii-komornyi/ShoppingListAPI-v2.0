using System.Text.Json.Serialization;

namespace Models
{
    public class FileStorage
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
