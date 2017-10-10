using Microsoft.EntityFrameworkCore;

namespace ProductApi.Models
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext>options):base(options)
        {}

        public DbSet<ProductGroup> ProductGroupTable {get;set;}

        public DbSet<ProductInfo> ProductInfoTable {get;set;}
    }

}