using InventoryManagementApp.Application.Automapper;
using InventoryManagementApp.Application.Extensions;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Infrastructure.DataAccess;
using InventoryManagementApp.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddBusinessServices();
builder.Services.AddRepositoryServices();
builder.Services.AddDbContext<InventoryDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "qwertyuopasdfghjklizxcvbnm1234567890!@#$%&*()_-+=<>?QWERTYUOPASDFGHJKLIZXCVBNM";

    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireDigit = false;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
    options.Lockout.MaxFailedAccessAttempts = 3;

}).AddDefaultTokenProviders()
  .AddEntityFrameworkStores<InventoryDbContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();