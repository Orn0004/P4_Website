﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P4ProjectWebsite.Models
{
    public class BidEntity
    {
        public int Bid { get; set; }
        public string SupplierUsername { get; set; }
        public string ContributorUsername { get; set; }
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string DateCreated { get; set; }
    }
}
