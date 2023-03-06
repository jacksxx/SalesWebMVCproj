using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMVCproj.Data;
using SalesWebMVCproj.Models;
using SalesWebMVCproj.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

//
var builder = WebApplication.CreateBuilder(args);

//Add Server
string MySqlconnection = builder.Configuration.GetConnectionString("SalesWebMVCprojContext");

builder.Services.AddDbContext<SalesWebMVCprojContext>(options =>
    options.UseMySql(MySqlconnection, ServerVersion.AutoDetect(MySqlconnection)
    ?? throw new InvalidOperationException("Connection string 'SalesWebMVCprojContext' not found.")
    , builder => builder.MigrationsAssembly("SalesWebMVCproj")));


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<SalesRecordService>();
//application
var app = builder.Build();

//Localization
var enUs = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(enUs),
    SupportedCultures = new List<CultureInfo> { enUs },
    SupportedUICultures = new List<CultureInfo> { enUs }
};
app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//Seeds
app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
