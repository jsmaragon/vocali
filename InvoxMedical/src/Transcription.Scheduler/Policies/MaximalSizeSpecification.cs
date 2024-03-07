using Transcription.Scheduler.Model;
using Transcription.Scheduler.Policies.Infrastructure;

namespace Transcription.Scheduler.Policies
{
    public class MaximalSizeSpecification : ISpecification<MedicalRecord>
    {
        private long _maxSize;

        public MaximalSizeSpecification(long maximumSize)
        {
            _maxSize = maximumSize;
        }

        public bool IsSatisfiedBy(MedicalRecord obj)
        {
            return (obj.RecordFile.Length <= _maxSize);
        }
    }
}
