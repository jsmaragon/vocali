namespace Transcription.Scheduler.Settings
{
    public class SchedulerSettings : ISchedulerSettings
    {
        public string MedicalRecordsFolder { get; set; }
        public string CronExpression { get; set; }
    }
}
