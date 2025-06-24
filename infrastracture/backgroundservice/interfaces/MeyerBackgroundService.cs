using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using infrastracture.externalservices.meyerapi.interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace infrastracture.backgroundservice.interfaces
{
    public class MeyerBackgroundService : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;
        public MeyerBackgroundService(IConfiguration configuration,IServiceProvider serviceProvider)
        {
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    //Log kaydı atılacak, çalıştırıldı diye.
                    using (var scope = _serviceProvider.CreateScope()) 
                    {

                        var meyerSicilService = scope.ServiceProvider.GetRequiredService<IMeyerSetSicilService>();
                        await meyerSicilService.MeyerSetSicilAsync();
                    }

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "chrome",
                        Arguments = "https://www.google.com",
                        UseShellExecute = true
                    });
                }
                catch (System.Exception ex)
                {
                     //Log kaydı atılacak
                }
                var minutes = Convert.ToDouble(_configuration.GetSection("MeyerBackgroundService:Minutes").Value);
                await Task.Delay(TimeSpan.FromMinutes(minutes), stoppingToken);
            }
            
        }
    }
}