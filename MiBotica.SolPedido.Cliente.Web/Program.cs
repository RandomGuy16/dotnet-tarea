using Microsoft.AspNetCore.Authentication.Cookies;
using MiBotica.SolPedido.AccesoDatos.Core;

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
builder.Services.AddControllersWithViews();

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

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
