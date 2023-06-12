using EcommerceApplication.DBContext;
using EcommerceApplication.IRepository.Carts;
using EcommerceApplication.IRepository.Products;
using EcommerceApplication.IRepository.Users;
using EcommerceApplication.Repository.Carts;
using EcommerceApplication.Repository.Products;
using EcommerceApplication.Repository.Users;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding DB context
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Adding interfaces
builder.Services.AddScoped<IUserRepoBasics, UserRepoBasics>();
builder.Services.AddScoped<IUserRepoCRUD, UserRepoCRUD>();
builder.Services.AddScoped<ICategoryCRUD, CategoryCRUD>();
builder.Services.AddScoped<ITagCRUD, TagCRUD>();
builder.Services.AddScoped<ICartRepoCRUD, CartRepoCRUD>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
