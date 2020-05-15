using System;
using System.Collections.Generic;
using System.Text;

namespace P4ProjectWebsite.Models
{
    public class Tasks
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Salary { get; set; }
        public int Duration { get; set; }
        public int Id { get; }
        public string Location { get; set; }
    }
}
