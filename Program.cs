using System.Data;
using Microsoft.Data.SqlClient;
using PIM_IV.Models;
using PIM_IV.Repositories;

var builder = WebApplication.CreateBuilder(args);

string connectionString = @"Server=RTHEODORO\LOCALHOST;Database=PIM_IV;user='user';password='174201';TrustServerCertificate=True;";

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));
builder.Services.AddScoped<IRepository<Cliente>, ClienteRepository>();
builder.Services.AddScoped<IRepository<Compra>, CompraRepository>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cliente}/{action=Index}/{id?}");

app.Run();