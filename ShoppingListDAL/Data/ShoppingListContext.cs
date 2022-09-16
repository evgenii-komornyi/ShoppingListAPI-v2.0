using Microsoft.EntityFrameworkCore;
using Models;

namespace ShoppingListDAL.Data
{
    public class ShoppingListContext : DbContext
    {
        public ShoppingListContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
