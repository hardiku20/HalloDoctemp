using BusinessLogic.Interfaces;
using BusinessLogic.Repositories;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAssignmentInterface, AssignmentRepository>();

builder.Services.AddDbContext<AssigmentContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("AssigmentContext"))); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/Admin"))
    {
        context.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
        context.Response.Headers.Add("Pragma", "no-cache");
        context.Response.Headers.Add("Expires", "0");
    }

    await next.Invoke();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Assignment}/{action=Dashboard}/{id?}");

app.Run();
