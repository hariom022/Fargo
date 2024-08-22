using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CITApplication;
//using CleanArchitecture.Domain;
using CITInfrastructure;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.AspNetCore.Builder;
using CITDomain.Interfaces;
using CITInfrastructure.Repository;
using CITApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var Configuration = builder.Configuration;

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.RegisterApplicationsServices(Configuration);
builder.Services.RegisterInfrastructureServices(Configuration);


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
//app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Overview}/{id?}");

app.Run();