using BaiTapNho.Models;
using Microsoft.EntityFrameworkCore;

namespace BaiTapNho.Data;

public class BaiTapNhoDbContext : DbContext
{
    public BaiTapNhoDbContext(
        DbContextOptions<BaiTapNhoDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // quan he user - order: 1-n
        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);
        
        // quan he order - order_detail: 1-n
        modelBuilder.Entity<OrderDetail>()
            .HasOne(or => or.Product)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(od => od.ProductId);
        
        // quan he product - order_detail: 1-n
        modelBuilder.Entity<OrderDetail>()
            .HasOne(or => or.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(or => or.OrderId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlite("Data Source=mydatabase.db");
    }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<OrderDetail> OrderDetails { get; set; }
}