using BAOCAO2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// --- CORS: cho phép frontend truy cập
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // port Vite
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// --- DbContext (SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// --- Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BÁO CÁO LẬP TRÌNH .NET C#",
        Description = "RESTful API DEMO QUẢN LÝ SẢN PHẨM"
    });
});

var app = builder.Build();

// --- Apply CORS
app.UseCors("AllowFrontend");

// --- Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BAOCAO2 Products API v1");
        c.RoutePrefix = "swagger";

        // 🔥 Quan trọng: dùng giao diện custom
        c.IndexStream = () => File.OpenRead("wwwroot/GIAODIEN/index.html");
    });
}

// --- Middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
