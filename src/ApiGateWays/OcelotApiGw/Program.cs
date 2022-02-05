using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Logging;
using Serilog;

namespace OcelotApiGw
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingcontext, config) =>
            {
                config.AddJsonFile($"ocelot.{hostingcontext.HostingEnvironment.EnvironmentName}.json", true, true);
            })
             .ConfigureWebHostDefaults(webBuilder =>
             {
                 webBuilder.UseStartup<Startup>();
             })
             .UseSerilog(SeriLogger.Configure);
            //.ConfigureLogging((hostingcontext, loggingbuilder) =>
            //    {
            //        loggingbuilder.AddConfiguration(hostingcontext.Configuration.GetSection("Logging"));
            //        loggingbuilder.AddConsole();
            //        loggingbuilder.AddDebug();
            //    });
    }
}
