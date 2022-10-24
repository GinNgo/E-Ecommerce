using E_Ecommerce_Backend.Data;
using E_Ecommerce_Backend.Service.ProductService;
using E_Ecommerce_Backend.Services.CategoryService;
using E_Ecommerce_Backend.Services.ProductService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EcommecreDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("EcommerceDB"));
});
//interface

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Upload")),
    RequestPath = new PathString("/wwwroot/Upload")
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
