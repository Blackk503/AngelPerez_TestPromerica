using ApiProductos.Data;
using Infrastructure.Data;
using Infrastructure.Interfaces.IRepositories;
using Infrastructure.Interfaces.IServices;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
#endregion

#region Services
builder.Services.AddScoped<IProductServices, ProductServices>();
#endregion

builder.Services.AddDbContext<PersistenceContext>
    (o => o.UseInMemoryDatabase("TestPromerica"));

var app = builder.Build();

DbInitializer.AddCustomerData(app);

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
