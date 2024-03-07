using System;
using System.Collections.Generic;
using System.Text;
using Transcription.Scheduler.Model;
using Transcription.Scheduler.Policies.Infrastructure;

namespace Transcription.Scheduler.Policies
{
    public class ValidMp3FormatSpecification : ISpecification<MedicalRecord>
    {
        public ValidMp3FormatSpecification()
        {

        }

        public bool IsSatisfiedBy(MedicalRecord obj)
        {
            // by now, this is simple policy, in the future,
            // we could check https://stackoverflow.com/a/7303520/352865

            return obj.RecordFile.Extension == "mp3";
        }
    }
}
