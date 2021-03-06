﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P4ProjectWebsite.Models
{
    public class TaskEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int LowestBid { get; set; }
        public int Duration { get; set; }
        public int Id { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string DateCreated { get; set; }
        public string CreatedBy { get; set; }

    }
}
