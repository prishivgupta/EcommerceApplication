using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.DataAccess;
using Users.DataAccess.Interfaces;
using Users.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EcommerceContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IAuth, AuthRepository>();

builder.Services.AddMediatR(typeof(AuthRepository).Assembly);
builder.Services.AddMediatR(typeof(UserRepository).Assembly);

builder.Services.AddCors(options =>
{

    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
