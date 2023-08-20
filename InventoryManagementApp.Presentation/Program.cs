using InventoryManagementApp.Application.Extensions;
using InventoryManagementApp.Infrastructure.DataAccess;
using InventoryManagementApp.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddBusinessServices();
builder.Services.AddRepositoryServices();
builder.Services.AddDbContext<InventoryDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
