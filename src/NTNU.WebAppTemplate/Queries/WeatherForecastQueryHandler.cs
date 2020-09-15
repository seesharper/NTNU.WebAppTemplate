using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Query.Abstractions;
using NTNU.WebAppTemlate;

namespace NTNU.WebAppTemplate.Queries
{
    public class WeatherForecastQueryHandler : IQueryHandler<WeatherForecastQuery, WeatherForecast[]>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastQueryHandler(IFoo foo)
        {
            // Notice that we come in here with "FooMock" if we override the default regsitration. See IntegrationTestsWithMock.
        }

        public async Task<WeatherForecast[]> HandleAsync(WeatherForecastQuery query, CancellationToken cancellationToken = default)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }

    public class WeatherForecastQuery : IQuery<WeatherForecast[]>
    {

    }
}