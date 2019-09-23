using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace OSIRIS.Api
{
    public class Program
    {
#pragma warning disable CS1591
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Verbose()
                                .WriteTo.Console()
                                .WriteTo.File("Logs\\OSIRIS-log.txt", rollingInterval: RollingInterval.Minute)
                                .CreateLogger();

            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
#pragma warning restore CS1591
}
