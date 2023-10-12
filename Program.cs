using BlogApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogDbContext>(opt=>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});
var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(name: "areaRoute", areaName: "Admin", pattern: "{Area}/{Controller}/{Action}/{id?}");
    endpoints.MapDefaultControllerRoute();
});




app.Run();
