using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZBuild.Common.Models
{
    public class Trait
    {
        public int TraitID { get; set; }
        public string Name { get; set;}
        public string Description { get; set; }
        public bool IsPositive { get; set; }
        public bool IsOccupationExclusive { get; set; }
        public int Point { get; set; }
        public string Effect { get; set; }
        public string Icon { get; set; }
        public Guid TraitGuid { get; set; }

        public virtual ICollection<Occupation> Occupations { get; set; }
    }
}
