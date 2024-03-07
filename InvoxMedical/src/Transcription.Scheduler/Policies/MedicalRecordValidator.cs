using Transcription.Scheduler.Model;
using Transcription.Scheduler.Policies.Infrastructure;

namespace Transcription.Scheduler.Policies
{
    public class MedicalRecordValidator : Validator<MedicalRecord>
    {
        public MedicalRecordValidator()
        {
            /*  
             *  Add(new Rule<Order>(new ClientMustBeActive(repository), "Client must be active!"));
            Add(new Rule<Order>(new ClientMustBePremiumMember(repository), "Client must be a premium member!"));
             */

            Add(new Rule<MedicalRecord>(new MinimalSizeSpecification(50Kb), "Minimum Size 50kb"));
        }

    }
}
