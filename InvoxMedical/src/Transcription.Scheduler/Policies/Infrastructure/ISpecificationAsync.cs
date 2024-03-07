using System.Threading.Tasks;

namespace Transcription.Scheduler.Policies.Infrastructure
{
    public interface ISpecificationAsync<in T>
    {
        Task<bool> IsSatisfiedBy(T obj);
    }
}