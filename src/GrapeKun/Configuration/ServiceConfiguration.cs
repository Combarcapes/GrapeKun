using GrapeKun.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrapeKun.Configuration
{
    public class ServiceConfiguration
    {

        private ServiceProvider serviceProvider;

        public ServiceProvider ServiceProvider
        {
            get { return serviceProvider; }
        }

        public ServiceConfiguration(IServiceCollection services)
        {
            //Add Logging Service           
            services.AddSingleton<Logging.ILogger, Logger>();
            serviceProvider = services.BuildServiceProvider();   
  
        }
    }
}
