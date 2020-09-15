using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Query.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NTNU.WebAppTemplate.Queries;

namespace NTNU.WebAppTemlate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IQueryExecutor queryExecutor;

        public WeatherForecastController(IQueryExecutor queryExecutor) => this.queryExecutor = queryExecutor;

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get() => await queryExecutor.ExecuteAsync(new WeatherForecastQuery());
    }
}
