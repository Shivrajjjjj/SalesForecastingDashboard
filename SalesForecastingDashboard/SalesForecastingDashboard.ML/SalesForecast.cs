using Microsoft.ML.Data;

namespace SalesForecastingDashboard.ML
{
    public class SalesForecast
    {
        [VectorType(6)] // Number of predictions
        public float[] ForecastedSales { get; set; } = new float[6];

        public float[] LowerBoundSales { get; set; }
        public float[] UpperBoundSales { get; set; }
    }
}
