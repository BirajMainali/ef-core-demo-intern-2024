using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Efcore_demo.Data;
using Efcore_demo.Repositories;
using Efcore_demo.Repositories.Interfaces;
using Efcore_demo.Services;
using Efcore_demo.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");



builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IFoodService, FoodService>();

builder.Services.AddScoped<IFoodRepository, FoodRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=FoodController1}/{action=Create}/{id?}");


app.Run();