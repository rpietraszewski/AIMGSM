using AIMGSM.Contexts;
using AIMGSM.Services;
using AIMGSM.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using AIMGSM.Repositories;
using AIMGSM.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<GlobalContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddTransient<IContactService, ContactService>();

builder.Services.AddTransient<IServiceService, ServiceService>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();

builder.Services.AddTransient<IDeviceService, DeviceService>();
builder.Services.AddTransient<IDeviceRepository, DeviceRepository>();

builder.Services.AddTransient<IPriceService, PriceService>();
builder.Services.AddTransient<IPriceRepository, PriceRepository>();

builder.Services.AddTransient<IBlogService, BlogService>();
builder.Services.AddTransient<IBlogRepository, IBlogRepository>();

builder.Services.AddTransient<IFormService, FormService>();
builder.Services.AddTransient<IFormRepository, FormRepository>();

// Add services to the container.
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddMvc();
builder.Services.AddControllersWithViews();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
