using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.Configuration;
using Spiralogics.Logger;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DataParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var mutex = new Mutex(false, "DataParser SingletonApp"))
            {
                bool isAnotherInstanceOpen = !mutex.WaitOne(TimeSpan.Zero);
                if (isAnotherInstanceOpen)
                {
                    Console.WriteLine("******************************************************");
                    Console.WriteLine("One instance of this application is already running.");
                    Console.WriteLine("******************************************************");
                    return;
                }
                #region Application                   
                var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                var configuration = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json", false)
                                    .AddJsonFile($"appsettings.{environmentName}.json", false)
                                    .Build();
                SettingConfig settingConfig = new SettingConfig();
                configuration.GetSection("ApplicationSettings").Bind(settingConfig);
                settingConfig.Environment = environmentName;

                GlobalConfiguration.Configuration.UseSqlServerStorage(settingConfig.ConnectionString);

                using (var server = new BackgroundJobServer())
                {
                    try
                {
                       
                        SmtpAPI smtpAPI = null;
                        if (environmentName.ToLower() == "testing")
                        {
                            smtpAPI = new SmtpAPI();
                            configuration.GetSection("SmtpSettings").Bind(smtpAPI);
                        }

                        SpiralogicsLog.InitiInitializeLogger(configuration, new SeriLogLogger());

                        Console.WriteLine("Hangfire Server started. Press ENTER to exit...");
                        EmailSender emailSender = new EmailSender(smtpAPI);
                        ReadClaim readClaim = new ReadClaim();
                        readClaim.ParseHook += emailSender.SendEMail;
                        readClaim.ReadClaimInputFiles(settingConfig);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error Occured due to appsettings JSON file invalid value :" + ex.Message);
                    }
                    finally
                    {
                       // Thread.Sleep(10000);//for serilog logging 
                        SpiralogicsLog.CloseLogger();
                    }
                }
            #endregion


            mutex.ReleaseMutex();
                Environment.Exit(0);
            }
        } 
    }
}
