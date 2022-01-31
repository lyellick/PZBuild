using PZBuild.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZBuild.Common.Models
{
    public class Skill
    {
        public int SkillID { get; set; }
        public string Name { get; set; }
        public string Effect { get; set; }
        public SkillTypes SkillType { get; set; }
        public Guid SkillGuid { get; set; }

        public virtual ICollection<OccupationSkill> OccupationSkills { get; set; }
    }
}
