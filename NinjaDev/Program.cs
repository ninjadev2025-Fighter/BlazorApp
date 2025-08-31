using Microsoft.EntityFrameworkCore;
using NinjaDev.Components;
using NinjaDev.Data.Context;
using NinjaDev.Domain;
using NinjaDev.Domain.Interfaces;
using NinjaDev.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("NinjaDevDB")
));

builder.Services.AddScoped<ICategoryRepository, CategoryService>();
builder.Services.AddScoped<IProductRepository, ProductService>();







var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();




using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}


    app.Run();
