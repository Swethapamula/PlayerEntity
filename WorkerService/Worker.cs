using DataLibrary.BuisnessLogic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        //private readonly ILogger<Worker> _logger;
        private HttpClient client;
        private IConfiguration Configuration;

        //public Worker(ILogger<Worker> logger)
        //{
        //    _logger = logger;
        //}
        public Worker(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            client = new HttpClient();
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            client.Dispose();
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string conString = this.Configuration.GetConnectionString("MVCDemoDB");

            while (!stoppingToken.IsCancellationRequested)
            {
                var result = await client.GetAsync("https://www.google.com");
                if (result.IsSuccessStatusCode)
                {
                    //_logger.LogInformation("The website is up. with status code {StatusCode}", result.StatusCode);
                    WorkerProcessor.CreateWorker (DateTime.UtcNow,
                        result.StatusCode.ToString(), "The website is up", conString);
                }
                else
                {
                    //_logger.LogError("The website is down. with status code {StatusCode}", result.StatusCode);
                    WorkerProcessor.CreateWorker(DateTime.UtcNow,
                       result.StatusCode.ToString(), "The website is down", conString);
                }

                await Task.Delay((60 * 1000), stoppingToken);
            }
        }
    }
}
