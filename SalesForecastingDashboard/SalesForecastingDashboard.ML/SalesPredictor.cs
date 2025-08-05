using Microsoft.ML;
using Microsoft.ML.Data;
using SalesForecastingDashboard.Shared;

namespace SalesForecastingDashboard.ML
{
    public class SalesPredictor
    {
        private readonly MLContext _mlContext;

        public SalesPredictor()
        {
            _mlContext = new MLContext();
        }

        public ITransformer Train(IEnumerable<SalesData> data)
        {
            var dataView = _mlContext.Data.LoadFromEnumerable(data);

            var pipeline = _mlContext.Forecasting.ForecastBySsa(
                outputColumnName: nameof(SalesForecast.ForecastedSales),
                inputColumnName: nameof(SalesData.Sales),
                windowSize: 5,
                seriesLength: 20,
                trainSize: 20,
                horizon: 6,
                confidenceLevel: 0.95f,
                confidenceLowerBoundColumn: nameof(SalesForecast.LowerBoundSales),
                confidenceUpperBoundColumn: nameof(SalesForecast.UpperBoundSales));

            return pipeline.Fit(dataView);
        }

        public float[] Predict(ITransformer model, IEnumerable<SalesData> data)
        {
            var dataView = _mlContext.Data.LoadFromEnumerable(data);

            // Apply the SSA time series model
            var transformedData = model.Transform(dataView);

            // Get the forecast from the last row
            var forecastResults = _mlContext.Data
                .CreateEnumerable<SalesForecast>(transformedData, reuseRowObject: false)
                .ToList();

            return forecastResults.LastOrDefault()?.ForecastedSales ?? new float[0];
        }
    }
}
