using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.DataAccess.Interfaces;
using Order.Repositories;
using Products.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EcommerceContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});

builder.Services.AddScoped<IOrder, OrderRepository>();

builder.Services.AddMediatR(typeof(OrderRepository).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
