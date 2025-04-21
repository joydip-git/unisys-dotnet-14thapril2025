using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DataAccessUsingEFCore.Repository
{
    public class ProductDbContext : DbContext
    {
        //version-1:
        //private readonly string conStr;
        //public ProductDbContext(string conStr)
        //{
        //    this.conStr = conStr;
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(conStr);
        //}

        //version-2:        
        public ProductDbContext(DbContextOptions<ProductDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Product> Products { get; set; }
    }
}
