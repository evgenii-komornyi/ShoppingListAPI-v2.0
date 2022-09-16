namespace ShoppingListDAL.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? FlatNumber { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? Phone { get; set; }
        public User User { get; set; }
    }
}
