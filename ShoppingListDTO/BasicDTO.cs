using Models.Errors;

namespace ShoppingListDTO
{
    public abstract class BasicDTO<E>
    {
        public Status status { get; set; }
        public List<E>? validationErrors { get; set; }
        public List<DatabaseErrors>? dbErrors { get; set; }
        public string? Exception { get; set; }
    }
}
