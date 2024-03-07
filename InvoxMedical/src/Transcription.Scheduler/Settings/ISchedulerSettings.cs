namespace Transcription.Scheduler.Settings
{
    public interface ISchedulerSettings
    {
        string MedicalRecordsFolder { get; set; }

        string CronExpression { get; set; }

    }
}