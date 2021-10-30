using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Scrape
{
    public class Worker : BackgroundService
    {
        private readonly IPinterestAgent _pinterestAgent;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly IConfiguration _configuration;
        private readonly ILogger<Worker> _logger;

        public Worker(
            IPinterestAgent pinterestAgent,
            IHostApplicationLifetime hostApplicationLifetime,
            IConfiguration configuration,
            ILogger<Worker> logger)
        {
            _pinterestAgent = pinterestAgent;
            _hostApplicationLifetime = hostApplicationLifetime;
            _configuration = configuration;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            string[] keywords = _configuration.GetSection("Keywords").Get<string[]>();

            string data = await _pinterestAgent.GetData(keywords);
            _logger.LogInformation(data);

            await Task.Delay(1000, stoppingToken);

            _hostApplicationLifetime.StopApplication();
        }
    }
}
