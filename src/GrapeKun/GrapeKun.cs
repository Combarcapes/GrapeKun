using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using Discord.WebSocket;
using GrapeKun.Logging;

namespace GrapeKun
{
    public class GrapeKun
    {
        private ILogger logger;

        public GrapeKun(ILogger logger)
        {
            this.logger = logger;
        }
        
        /// <summary>
        /// Calls the main client loop.
        /// </summary>
        public void Run() => Task.Run(() => this.MainAsync()).GetAwaiter().GetResult();

        /// <summary>
        /// Main client loop. Will not return anything until the client terminates, this is to allow bot to be continually monitoring channels
        /// </summary>
        /// <returns> Main loop task </returns>
        private async Task MainAsync()
        {
            var client = new DiscordSocketClient();
            
            client.Log += Log;

            Configuration = AppSettings();

            string token = Configuration["Token"].Trim();
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            
            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private Task Log(LogMessage message)
        {
            logger.Info(message.ToString());
            return Task.CompletedTask;
        }

        /// <summary>
        /// Gets data from AppSettings.JSON
        /// </summary>
        /// <returns>Contents of the AppSettings file</returns>
        private IConfigurationRoot AppSettings()
        {
            var appSettings = new ConfigurationBuilder()
           .SetBasePath($"{Directory.GetCurrentDirectory()}/Configuration/")
           .AddJsonFile("AppSettings.json", optional: false, reloadOnChange: true);

            return appSettings.Build();
        }

        /// <summary>
        /// Stores AppSettings variables
        /// </summary>
        private static IConfigurationRoot Configuration { get; set; }
  
    }
}