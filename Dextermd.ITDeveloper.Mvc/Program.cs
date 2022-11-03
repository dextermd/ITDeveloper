using Dextermd.ITDeveloper.Data.ORM;
using Dextermd.ITDeveloper.Domain.Models;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ITDeveloperDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultITDeveloper")
    ));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
