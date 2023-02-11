using Microsoft.EntityFrameworkCore;
using WebAppAssignment1.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(o=>o.UseSqlServer(connection));

var app = builder.Build();

app.MapControllerRoute(
    name: "default", 
    pattern: "{controller=Home}/{action=Create}/{id?}");

app.UseStaticFiles();

app.Run();
