using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BAOCAO2.Data;
using BAOCAO2.Models;

namespace BAOCAO2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProductsController(AppDbContext db)
        {
            _db = db;
        }

        // GET /api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _db.Products.ToListAsync();
            return Ok(new { status = "Thành công", message = "Lấy danh sách sản phẩm", data = products });
        }

        // GET /api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
                return NotFound(new { status = "Không thấy", message = "Không tìm thấy sản phẩm" });

            return Ok(new { status = "Thành công", message = "Lấy sản phẩm thành công", data = product });
        }

        // POST /api/products
        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            if (product == null)
                return BadRequest(new { status = "Sai", message = "Yêu cầu không hợp lệ" });

            _db.Products.Add(product);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById),
                new { id = product.Id },
                new { status = "Đã thêm mới", message = "Thêm sản phẩm thành công", data = product });
        }

        // PUT /api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest(new { status = "Sai", message = "ID không khớp" });

            var exist = await _db.Products.AnyAsync(p => p.Id == id);
            if (!exist)
                return NotFound(new { status = "Không thấy", message = "Không tìm thấy sản phẩm để cập nhật" });

            _db.Entry(product).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return Ok(new { status = "Thành công", message = "Cập nhật sản phẩm thành công", data = product });
        }

        // DELETE /api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
                return NotFound(new { status = "Không thấy", message = "Không tìm thấy sản phẩm để xóa" });

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();

            return Ok(new { status = "Thành công", message = "Xóa sản phẩm thành công" });
        }
    }
}
