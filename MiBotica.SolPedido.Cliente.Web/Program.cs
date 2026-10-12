using System;
using System.IO;
using Microsoft.AspNetCore.Authentication.Cookies;
using MiBotica.SolPedido.AccesoDatos.Core;
using MiBotica.SolPedido.Entidades.Filter;

// initialize log4net
var logConfigPath = Path.Combine(AppContext.BaseDirectory, "log4net.config");
if (File.Exists(logConfigPath))
{
    log4net.Config.XmlConfigurator.Configure(new FileInfo(logConfigPath));
}

var builder = WebApplication.CreateBuilder(args);

// Initialize Data Access connection string replicating the professor's pattern:
// AppSettings:cnnSql pointer -> ConnectionStrings[pointer]
BaseDA.Initialize(builder.Configuration);

// Add services to the container.
// Equivalente a FilterConfig.RegisterGlobalFilters() del App_Start en MVC5:
// hace que ExceptionFilterAtributes se aplique a TODOS los controladores
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new ExceptionFilterAtributes());
});

// Configure Authentication replicating FormsAuthentication (Paso 46)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.LogoutPath = "/Login/CerrarSesion";
    });

// Configure Session support
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Manejo de errores personalizado (equivalente a <customErrors mode="On"> de Web.config)
app.UseExceptionHandler("/Home/Error500");           // statusCode="500"
app.UseStatusCodePagesWithReExecute("/Home/PaginaNoEncontrada"); // statusCode="404"

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
