using Microsoft.EntityFrameworkCore;
using ShoppingListDAL.Data;
using Constants;
using ShoppingListBLL.Services;
using ShoppingListBLL.Validations;
using ShoppingListDAL.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IFileStorageRepository, FileStorageRepository>();
builder.Services.AddScoped<IFileStorageService, FileStorageService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddTransient<ProductValidation>();
builder.Services.AddTransient<CreateRequestValidation>();
builder.Services.AddTransient<FindRequestValidation>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ShoppingListContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(ConstantsRepository.LocalConnectionString));
});
builder.Services.AddCors(p => p.AddPolicy("reactapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("reactapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

 app.Run();
