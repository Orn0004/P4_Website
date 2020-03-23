using System;
using System.Collections.Generic;
using System.Text;

namespace P4_Data.Entities
{
    public class Jobs
    {
        public string JobTitel { get; set; }
        public string JobBeskrivelse { get; set; }
        public int JobLøn { get; set; }
        public int JobVarighed { get; set; }
        public int ID { get; }
    }
}
