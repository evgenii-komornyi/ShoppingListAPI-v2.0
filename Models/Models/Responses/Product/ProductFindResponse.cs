namespace Models.Responses
{
    public class ProductFindResponse : ProductBasicResponse
    {
        public Product? FoundProduct { get; set; }
        public List<Product>? ListOfFoundProducts { get; set; }
    }
}
