using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace infrastracture.backgroundservice.interfaces
{
    public class MeyerBackgroundService : BackgroundService
    {
        private readonly IConfiguration _configuration;
        public MeyerBackgroundService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "chrome",
                        Arguments = "https://www.google.com",
                        UseShellExecute = true
                    });
                }
                catch (System.Exception ex)
                {
                     // TODO
                }
                var minutes = Convert.ToDouble(_configuration.GetSection("MeyerBackgroundService:Minutes").Value);
                await Task.Delay(TimeSpan.FromMinutes(minutes), stoppingToken);
            }
            
        }
    }
}