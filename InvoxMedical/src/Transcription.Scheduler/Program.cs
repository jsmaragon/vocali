using Coravel;
using Coravel.Scheduling.Schedule.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;
using Transcription.Scheduler.Settings;

public class Program
{
    public static async Task Main(string[] args)
    {

        var hostBuilder = new HostBuilder()
            .ConfigureAppConfiguration((hostContext, configBuilder) =>
            {
                configBuilder.SetBasePath(Directory.GetCurrentDirectory());
                configBuilder.AddJsonFile("appsettings.json", optional: true);
                configBuilder.AddEnvironmentVariables();
            })
            .ConfigureLogging((hostContext, configLogging) =>
            {
                configLogging.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
                configLogging.AddConsole();

            })
            .ConfigureServices((hostContext, services) =>
            {

                services.AddSingleton<ISchedulerSettings>(serviceProvider =>
                {
                    return hostContext.Configuration.GetSection("SchedulerSettings").Get<SchedulerSettings>();
                });
                services.AddScheduler();
                services.AddTransient<MedicalRecordUploader>();

                // Here goes your internal application dependencies
                // like EntityFramework context, worker, endpoint, etc.
            });

        IHost host = hostBuilder.Build();


        var settings = host.Services.GetService<ISchedulerSettings>();


        host.Services.UseScheduler(scheduler =>
        {

            if (IsDevelopment(host))
            {
                // This is for development purposes
                scheduler.Schedule<MedicalRecordUploader>()
                .EveryFiveSeconds();
            }
            else
            {
                scheduler.Schedule<MedicalRecordUploader>()
               .Cron(settings.CronExpression);
            }

        });

        await host.RunAsync();
    }


    private static bool IsDevelopment(IHost host)
    {

        return host.Services.GetService<IConfiguration>().GetValue<string>("Environment")=="Development";

    }
}