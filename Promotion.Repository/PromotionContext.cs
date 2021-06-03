using Microsoft.EntityFrameworkCore;
using Promotion.Model;

namespace Promotion.Repository
{
    public class PromotionContext : DbContext
    {
        public PromotionContext(DbContextOptions<PromotionContext> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
    }
}
