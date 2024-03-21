using learning1.DBEntities.Models;
using Microsoft.EntityFrameworkCore;
using learning1.Services.IServices;
using learning1.Repositories.IRepositories;
using learning1.Services.Services;
using learning1.Repositories.Repositories;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddDbContext<DbHallodocContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DbHallodocContext")));

builder.Services.AddScoped<IPatientRepo, PatientRepo>();
builder.Services.AddScoped<IPatientServices, PatientServices>();
builder.Services.AddScoped<IAdminServices, AdminServices>();
builder.Services.AddScoped<IAdminRepo, AdminRepo>();
builder.Services.AddScoped<IJWTService, JWTService>();
builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = false; config.Position = NotyfPosition.TopCenter; });



builder.Services.AddDbContext<learning1.DBEntities.Models.DbHallodocContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DbHallodocContext")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseNotyf();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=patientsite}/{id?}");
app.MapControllerRoute(
    name:"default",
    pattern: "{controller=Admin}/{action=admindashboard}/{id?}");



//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Admin}/{action=admindashboard}/{id?}");

app.Run();
