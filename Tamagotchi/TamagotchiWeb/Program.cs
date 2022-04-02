using MediatR;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TamagotchiWeb.Data;
using TamagotchiWeb.Data.Repositories;
using TamagotchiWeb.Data.Repositories.Interfaces;
using Mapster;
using TamagotchiWeb.Application.AnimalTypes.Base.DTOs;
using TamagotchiWeb.Entities;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<Context>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var config = TypeAdapterConfig.GlobalSettings;
config.Apply(config.Scan(Assembly.GetExecutingAssembly()));
builder.Services.AddSingleton(config);

builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
builder.Services.AddTransient<IAnimalTypeRepository, AnimalTypeRepository>();
builder.Services.AddTransient<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();


builder.Services.AddMvc();
builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
builder.Services.AddTransient<IMediator, Mediator>();
builder.Services.AddScoped<IMapper, ServiceMapper>();

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

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
