using Microsoft.EntityFrameworkCore;
using CrudAsignaciones.Data;
using Microsoft.AspNetCore.Components.Web.Virtualization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// --> REGISTRO DEL CONTEXTO DE BASE DE DATOS

builder.Services.AddDbContext<EmpresaDbContext>(item =>
item.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// --> REGISTRO DEL CONTEXTO DE BASE DE DATOS

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
