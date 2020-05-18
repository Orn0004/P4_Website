using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P4ProjectWebsite.Models
{
    public class CategoryEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
    public class CategoryDisplay
    {
        public IEnumerable<string> Name { get; set; }
        public IEnumerable<string> Type { get; set; }
    }
}
