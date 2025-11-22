using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BAOCAO2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Điện thoại Samsung A55", 8000000.0 },
                    { 2, "Laptop Asus VivoBook", 14500000.0 },
                    { 3, "Chuột Logitech G102", 350000.0 },
                    { 4, "Bàn phím cơ AKKO 3068", 1500000.0 },
                    { 5, "Tai nghe Sony WH-CH510", 1250000.0 },
                    { 6, "Loa Bluetooth JBL Go 3", 990000.0 },
                    { 7, "Máy tính bảng Lenovo M10", 5200000.0 },
                    { 8, "Màn hình LG 24 inch", 3200000.0 },
                    { 9, "Ổ cứng SSD Kingston 480GB", 850000.0 },
                    { 10, "Pin dự phòng Xiaomi 20000mAh", 650000.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
