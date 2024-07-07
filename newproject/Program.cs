using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using newproject.data;
using newproject.Logging;
using newproject.Models.Interface;
using newproject.Models.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



string? connString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Maindbcontext>(options => options.UseSqlServer(connString));
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddProvider(new DatabaseLoggerProvider(builder.Services.BuildServiceProvider()));
builder.Services.AddScoped<IAddress, AddressService>();
builder.Services.AddScoped<IStudent, StudentService>();
builder.Services.AddScoped<ICourse, CourseService>();
builder.Services.AddScoped<IEnrollment, EnrollmentService>();
builder.Services.AddControllersWithViews();
var app = builder.Build();


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
