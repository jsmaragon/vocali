using Coravel.Invocable;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using Transcription.Scheduler.Settings;

public class MedicalRecordUploader : IInvocable
{
    private readonly ILogger _logger;
    private readonly ISchedulerSettings _settings;

    //TODO: Inject directory, Specification (policies list) from https://nugetmusthaves.com/Package/SpecificationExpress

    public MedicalRecordUploader(ILogger<MedicalRecordUploader> logger, ISchedulerSettings settings)
    {
        _logger = logger;
        _settings = settings;
        _logger.LogDebug("MedicalRecordUploader ctor");
    }

    public Task Invoke()    
    {
        // Check medical records exists.. 

        if(!Directory.Exists(_settings.MedicalRecordsFolder))
        {
            throw new InvalidOperationException($"Directory {_settings.MedicalRecordsFolder} does not exists");
        }

        Console.WriteLine("This is my first invocable!");
        Console.WriteLine($"Will start processing {_settings.MedicalRecordsFolder}");
        return Task.CompletedTask;
    }
}
