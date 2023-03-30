using Microsoft.EntityFrameworkCore;
using WebApplication1.AppDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseMySQL(builder.Configuration.GetConnectionString("MySql")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
