using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UmeedPieShop.Models;

var builder = WebApplication.CreateBuilder(args);

string connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connString);

});

//Identity
builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>(); 

// Add services to the container.
builder.Services.AddControllersWithViews();

// Adding Services Dependencies injection
builder.Services.AddRazorPages();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp)); // <<<=====

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// ALL Details about request response session User
// Caching Services MiddlewareComponent 
builder.Services.AddHttpContextAccessor(); // <<<=====
builder.Services.AddSession(); // <<<=====


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession(); // <<<=====

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pie}/{action=PieOfWeek}/{id?}");

app.MapRazorPages();

app.Run();
