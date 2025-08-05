using Microsoft.EntityFrameworkCore;
using SalesForecastingDashboard.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add Razor Pages
builder.Services.AddRazorPages();

// Add EF Core DbContext (using SQL Server from appsettings.json)
builder.Services.AddDbContext<SalesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // 👈 This serves files from wwwroot

app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
