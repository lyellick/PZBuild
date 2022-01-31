using PZBuild.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZBuild.Common.Repositories.IRepositories
{
    public interface IOccupationSkillRepository
    {
        Task CreateOccupationSkill(OccupationSkill occupationSkill);

        Task CreateOccupationSkills(List<OccupationSkill> occupationSkills);

        void UpdateOccupationSkill(OccupationSkill occupationSkill);

        void UpdateOccupationSkills(List<OccupationSkill> occupationSkills);

        Task<OccupationSkill?> ReadOccupationSkill(int id);

        Task<List<OccupationSkill>> ReadOccupationSkills();

        void DeleteOccupationSkill(OccupationSkill occupationSkill);

        void DeleteOccupationSkills(List<OccupationSkill> occupationSkills);

        Task Save();
    }
}
