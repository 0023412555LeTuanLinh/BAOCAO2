namespace MyBlazorApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // tránh lỗi non-nullable
        public decimal Price { get; set; } = 0m;
    }
}
