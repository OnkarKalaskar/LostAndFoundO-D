using LostAndFound.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using LostAndFound.Configuration;
using LostAndFound.IServices;
using LostAndFound.Services;

var builder = WebApplication.CreateBuilder(args);

//adding auto mapper dependency
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperConfig());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

//adding dbcontext dependency
builder.Services.AddDbContext<LostAndFoundContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("connection"));
});


// Add services to the container.
builder.Services.AddTransient<IItemTableService, ItemTableService>();



builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
