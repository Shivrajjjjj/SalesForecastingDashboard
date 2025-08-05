using Microsoft.EntityFrameworkCore;
using SalesForecastingDashboard.Web.Models;

namespace SalesForecastingDashboard.Web.Data;

public class SalesDbContext : DbContext
{
    public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options) { }

    public DbSet<SalesEntry> SalesEntries { get; set; }
}
