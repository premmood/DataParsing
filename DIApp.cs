using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Threading.Tasks;

namespace DataParser
{
    public class DIApp
    {
        private readonly ILogger<DIApp> _logger;
       // private readonly SettingConfig _appSettings;
        private readonly IConfiguration _Configuration;
        public DIApp(IOptions<SettingConfig> appSettings, ILogger<DIApp> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
           // _appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
            _Configuration = configuration;
        }

        public async Task Run(string[] args)
        {
            _logger.LogInformation("Starting...");

            Console.WriteLine("Hello world!");

            var logDirectory = _Configuration.GetSection("ApplicationSettings");
            // Using serilog here, can be anything
            var log = new LoggerConfiguration()
                .WriteTo.Console()
               // .WriteTo.File(logDirectory)
                .CreateLogger();
           
            EmailSender emailSender = new EmailSender();
            ReadClaim readClaim = new ReadClaim();
            readClaim.ParseHook += emailSender.SendMail;
           //readClaim.ReadClaimInputFileDetailRecord(_appSettings);

           

            _logger.LogInformation("Finished!");
            Console.ReadLine();

            await Task.CompletedTask;
        }
    }
}
