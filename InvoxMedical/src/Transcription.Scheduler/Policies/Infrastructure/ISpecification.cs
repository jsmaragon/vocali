namespace Transcription.Scheduler.Policies.Infrastructure
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T obj);
    }
}