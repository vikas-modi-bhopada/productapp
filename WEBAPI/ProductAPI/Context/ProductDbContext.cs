using Microsoft.EntityFrameworkCore;
using ProductAPI.Model;

namespace ProductAPI.Context
{
    public class ProductDbContext:DbContext
    {
  
        public ProductDbContext()
        {
            
        }
        public ProductDbContext(DbContextOptions<ProductDbContext>Context):base(Context)
        {

        }
        public DbSet<Product> Products { get; set; }

    }
}
