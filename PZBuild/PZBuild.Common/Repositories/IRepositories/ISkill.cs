using PZBuild.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZBuild.Common.Repositories.IRepositories
{
    public interface ISkillRepository
    {
        Task CreateSkill(Skill skill);

        Task CreateSkills(List<Skill> skills);

        void UpdateSkill(Skill skill);

        void UpdateSkills(List<Skill> skills);

        Task<Skill?> ReadSkill(int id);

        Task<List<Skill>> ReadSkills();

        void DeleteSkill(Skill skill);

        void DeleteSkills(List<Skill> skills);

        Task Save();
    }
}
