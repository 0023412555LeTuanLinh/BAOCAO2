using BAOCAO2.Models;
using Microsoft.EntityFrameworkCore;

namespace BAOCAO2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Điện thoại Samsung A55", Price = 8000000 },
                new Product { Id = 2, Name = "Laptop Asus VivoBook", Price = 14500000 },
                new Product { Id = 3, Name = "Chuột Logitech G102", Price = 350000 },
                new Product { Id = 4, Name = "Bàn phím cơ AKKO 3068", Price = 1500000 },
                new Product { Id = 5, Name = "Tai nghe Sony WH-CH510", Price = 1250000 },
                new Product { Id = 6, Name = "Loa Bluetooth JBL Go 3", Price = 990000 },
                new Product { Id = 7, Name = "Máy tính bảng Lenovo M10", Price = 5200000 },
                new Product { Id = 8, Name = "Màn hình LG 24 inch", Price = 3200000 },
                new Product { Id = 9, Name = "Ổ cứng SSD Kingston 480GB", Price = 850000 },
                new Product { Id = 10, Name = "Pin dự phòng Xiaomi 20000mAh", Price = 650000 }
            );
        }
    }
}