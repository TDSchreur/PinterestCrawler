using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Scrape.Models;

namespace Scrape
{
    public class Worker : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly ILogger<Worker> _logger;
        private readonly IPinterestAgent _pinterestAgent;

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
            _logger.LogInformation("Worker running at: {Time}", DateTimeOffset.Now);

            string[] keywords = _configuration.GetSection("Keywords").Get<string[]>();

            ResponseModel data = await _pinterestAgent.GetData(keywords);

            foreach (Result item in data.ResourceResponse.Data.Results)
            {
                _logger.LogInformation("Image: {Uri}", item.Images.Orig.Url);
            }

            await Task.Delay(1000, stoppingToken);

            _hostApplicationLifetime.StopApplication();
        }
    }
}
