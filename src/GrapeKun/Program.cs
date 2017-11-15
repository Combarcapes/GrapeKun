using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrapeKun.Logging;
using GrapeKun.Configuration;

namespace GrapeKun
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Dependency Injection
            var services = new ServiceCollection();
            ServiceConfiguration configuration = new ServiceConfiguration(services);

            //Obtain Services
            var serviceProvider = configuration.ServiceProvider;

            //Get specific value
            ILogger logger = serviceProvider.GetService<ILogger>();

            //Give Birth to Grape-Kun!
            GrapeKun grapeKun = new GrapeKun(logger);

            //Run Grape-Kun!
            grapeKun.Run();

        }
    }
}
