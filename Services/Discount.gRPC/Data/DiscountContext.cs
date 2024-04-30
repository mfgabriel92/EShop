using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.Data;

public class DiscountContext(DbContextOptions<DiscountContext> options) : DbContext(options)
{
    public DbSet<Coupon> Coupons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon { Id = 1, ProductName = "Dell Inspiron 7472", Description = "Dell Inspiron 7472 laptop, 16GB RAM, 128GB SSD, Intel i7 8th Gen.", Amount = 150 }
        );
    }
}
