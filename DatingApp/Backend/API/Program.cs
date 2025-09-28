using API.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllers();
builder.Services.AddCors();
var app = builder.Build();


//services end

// Configure the HTTP request pipeline.

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:4200", "https://localhost:4200"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
