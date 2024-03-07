using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Transcription.Scheduler.Model
{
    public class MedicalRecord
    {
        public FileInfo RecordFile { get; set; }
        public string UserProfile { get; set; }
    }
}
