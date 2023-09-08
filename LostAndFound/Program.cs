using LostAndFound.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using LostAndFound.Configuration;
using LostAndFound.IServices;
using LostAndFound.Services;

var builder = WebApplication.CreateBuilder(args);



//adding dbcontext dependency
builder.Services.AddDbContext<LostAndFoundContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("connection"));
});

builder.Services.AddScoped<IItemDetailsService, ItemDetailsService>();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
