using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZBuild.Common.Models
{
    public class OccupationSkill
    {
        public string OccupationSkillID { get; set; }
        public string OccupationSkillGuid { get; set; }
        public int? StartingLevel { get; set; }
        public string? XPBoost { get; set; }

        public virtual Skill Skill { get; set; }
        public virtual Occupation Occupation { get; set; }
    }
}
