using Transcription.Scheduler.Policies.Infrastructure;
using Transcription.Scheduler.Model;

namespace Transcription.Scheduler.Policies
{
    public class MinimalSizeSpecification : ISpecification<MedicalRecord>
    {
        private long _minimunSize;

        public MinimalSizeSpecification(long minimumSize)
        {
            _minimunSize = minimumSize;
        }

        public bool IsSatisfiedBy(MedicalRecord obj)
        {
          return (obj.RecordFile.Length > _minimunSize);
        }
    }
}
