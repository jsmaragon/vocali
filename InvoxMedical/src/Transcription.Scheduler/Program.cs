using Coravel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

public class Program
{
    private static string _cronExpression; 
    public static async Task Main(string[] args)
    {
        
        var hostBuilder = new HostBuilder()
            .ConfigureAppConfiguration((hostContext, configBuilder) =>
            {
                configBuilder.SetBasePath(Directory.GetCurrentDirectory());
                configBuilder.AddJsonFile("appsettings.json", optional: true);
                configBuilder.AddJsonFile(
                    $"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json",
                    optional: true);
                configBuilder.AddEnvironmentVariables();
            })
            .ConfigureLogging((hostContext, configLogging) =>
            {
                configLogging.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
                configLogging.AddConsole();
            })
            .ConfigureServices((hostContext, services) =>
            {
                //IConfiguration config = hostContext.Configuration;
                //_cronExpression = config.GetValue<string>("Schedule");
                ////services.AddSingleton<IEndpointConfiguration>(serviceProvider =>
                //{
                //    return hostContext.Configuration.GetSection("EndpointConfiguration").Get<EndpointConfiguration>();
                //});
                services.AddScheduler();
                services.AddTransient<MedicalRecordUploader>();
                
                // Here goes your internal application dependencies
                // like EntityFramework context, worker, endpoint, etc.
            });

        IHost host = hostBuilder.Build();
        
       
        var config = host.Services.GetService<IConfiguration>();
        var cronExpression = config["Schedule"];
        host.Services.UseScheduler(scheduler =>
        {
            // Yes, it's this easy!
            scheduler
                .Schedule<MedicalRecordUploader>()
                .Cron(cronExpression);
                //.DailyAt(hour: 00, minute: 00);
                
        });

        await host.RunAsync();
    }
}