using Models.Errors;

namespace Models.Responses
{
    public class ProductBasicResponse : BasicResponse
    {
        public List<ProductValidationErrors>? ValidationErrors { get; set; }
        public List<DatabaseErrors>? DBErrors { get; set; }

        public bool HasValidationErrors()
        {
            return (ValidationErrors != null && ValidationErrors.Count != 0);
        }
        
        public bool HasDBErrors()
        {
            return (DBErrors != null && DBErrors.Count != 0);
        }
    }
}
