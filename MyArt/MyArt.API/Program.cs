using Microsoft.EntityFrameworkCore;
using MyArt.API.Infrastructure.Configurations;
using MyArt.DataAccess;
using MyArt.DataAccess.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer("Server=.\\SQLEXPRESS;Database=MyArt;Trusted_Connection=true"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IDataContext, DataContext>();

builder.Services.AddDataAccess();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
