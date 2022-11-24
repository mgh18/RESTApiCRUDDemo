using Microsoft.EntityFrameworkCore;
using RESTApiCRUDDemo.EmployeeData;
using RESTApiCRUDDemo.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IEmployeeData, MockEmployeeData>();
builder.Services.AddSingleton<IEmployeeData, MockEmployeeData>();
var connectionString = builder.Configuration.GetConnectionString("EmployeeContextConnectionString");
builder.Services.AddDbContextPool<EmployeeContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IEmployeeData,SqlEmployeeData>();
// Add services to the container.
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
    pattern: "{controller=Employees}/{action=Index}/{id?}");

app.Run();
