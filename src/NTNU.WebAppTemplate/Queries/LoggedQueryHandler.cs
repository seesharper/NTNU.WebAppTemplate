using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Query.Abstractions;
using Microsoft.Extensions.Logging;

namespace NTNU.WebAppTemplate.Queries
{
    public class LoggedQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> queryHandler;
        private readonly ILogger<LoggedQueryHandler<TQuery, TResult>> logger;

        public LoggedQueryHandler(IQueryHandler<TQuery, TResult> queryHandler, ILogger<LoggedQueryHandler<TQuery, TResult>> logger)
        {
            this.queryHandler = queryHandler;
            this.logger = logger;
        }

        public async Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            logger.LogInformation("Start");
            var result = await queryHandler.HandleAsync(query);
            logger.LogInformation($"Finished after {stopwatch.ElapsedMilliseconds}");
            return result;
        }
    }
}