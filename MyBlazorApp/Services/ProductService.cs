using System.Net.Http.Json;

namespace MyBlazorApp.Services
{
    public class ProductService
    {
        private readonly HttpClient _http;
        public ProductService(HttpClient http) => _http = http;

        public async Task<List<Product>> GetProductsAsync()
            => await _http.GetFromJsonAsync<List<Product>>("api/products");

        public async Task<Product> GetProductByIdAsync(int id)
            => await _http.GetFromJsonAsync<Product>($"api/products/{id}");

        public async Task AddProductAsync(Product product)
            => await _http.PostAsJsonAsync("api/products", product);

        public async Task UpdateProductAsync(Product product)
            => await _http.PutAsJsonAsync($"api/products/{product.Id}", product);

        public async Task DeleteProductAsync(int id)
            => await _http.DeleteAsync($"api/products/{id}");
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
