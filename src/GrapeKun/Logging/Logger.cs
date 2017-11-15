using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GrapeKun.Logging
{
    public class Logger : ILogger
    {
  
        public Logger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .Enrich.FromLogContext()
                .CreateLogger(); 
        }

        public void Debug(string message)
        {
            Log.Debug(message);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }

        public void Info(string message)
        {
            Log.Information(message);
        }
    }
}
