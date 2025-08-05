using CsvHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalesForecastingDashboard.ML;
using SalesForecastingDashboard.Shared;
using SalesForecastingDashboard.Web.Data;
using SalesForecastingDashboard.Web.Models;
using System.Globalization;

namespace SalesForecastingDashboard.Web.Pages
{
    public class ForecastModel : PageModel
    {
        private readonly SalesDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly SalesPredictor _predictor;

        public List<SalesData> HistoricalData { get; set; } = new();
        public float[] ForecastedSales { get; set; } = new float[0];
        public string[] Labels { get; set; } = new string[0];
        public float[] Data { get; set; } = new float[0];

        public ForecastModel(SalesDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
            _predictor = new SalesPredictor();
        }

        public void OnGet()
        {
            // ✅ Load CSV and seed DB if empty
            if (!_context.SalesEntries.Any())
            {
                var csvPath = Path.Combine(_env.WebRootPath, "uploads", "sales_data.csv");

                if (System.IO.File.Exists(csvPath))
                {
                    using var reader = new StreamReader(csvPath);
                    using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                    // Automatically map CSV to SalesData (including optional columns)
                    var records = csv.GetRecords<SalesData>().ToList();

                    // Save minimal required fields to DB
                    var entries = records.Select(r => new SalesEntry
                    {
                        Date = r.Date,
                        SalesAmount = r.Sales
                    }).ToList();

                    _context.SalesEntries.AddRange(entries);
                    _context.SaveChanges();

                    HistoricalData = records; // Save full record for Chart use
                }
            }

            // ✅ If DB already seeded, load from DB
            if (!HistoricalData.Any())
            {
                HistoricalData = _context.SalesEntries
                    .OrderBy(x => x.Date)
                    .Select(x => new SalesData
                    {
                        Date = x.Date,
                        Sales = (float)x.SalesAmount
                    }).ToList();
            }

            // ✅ Prepare chart values
            Data = HistoricalData.Select(x => x.Sales).ToArray();
            Labels = HistoricalData.Select(x => x.Date.ToString("yyyy-MM")).ToArray();

            // ✅ Forecast only if enough entries
            if (HistoricalData.Count >= 20)
            {
                var model = _predictor.Train(HistoricalData);
                ForecastedSales = _predictor.Predict(model, HistoricalData);
            }
        }
    }
}
