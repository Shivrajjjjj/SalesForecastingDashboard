using System.ComponentModel.DataAnnotations;

namespace SalesForecastingDashboard.Web.Models;

public class SalesEntry
{
    public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public double SalesAmount { get; set; }

  
}



