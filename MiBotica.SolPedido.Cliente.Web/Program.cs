using MiBotica.SolPedido.AccesoDatos.Core;

var builder = WebApplication.CreateBuilder(args);

// Initialize Data Access connection string from appsettings.json
var sqlConnection = builder.Configuration.GetConnectionString("SQL");
if (!string.IsNullOrEmpty(sqlConnection))
{
    BaseDA.Initialize(sqlConnection);
}

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
