using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P4ProjectWebsite.Models
{
    public class BidEntity
    {
        public bool Confirmation { get; set; }
        public int Bid { get; set; }
        public string SupplierId { get; set; }
        public string ContributorId { get; set; }
        public int Id { get; set; }
        public int TaskId { get; set; }
    }
}
