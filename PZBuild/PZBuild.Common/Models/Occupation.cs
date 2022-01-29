using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZBuild.Common.Models
{
    public class Occupation
    {
        public int OccupationID { get; set; }
        public string Name { get; set; }
        public string? Icon { get; set; }
        public Guid OccupationGuid { get; set; }

        public virtual ICollection<OccupationSkill> OccupationSkills { get; set; }
        public virtual Trait? ExclusiveTrait { get; set; }
    }
}
