using log4net.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            ILoggerRepository repository = log4net.LogManager.GetRepository(Assembly.GetEntryAssembly());
            var fileInfo = new FileInfo(@"log.config");
            log4net.Config.XmlConfigurator.Configure(repository, fileInfo);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
