using PZBuild.Common.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZBuild.Common.Services.IServices
{
    public interface IPZBuildService
    {
        IOccupationRepository OccupationRepository { get; }
        IOccupationSkillRepository OccupationSkillRepository { get; }
        ISkillRepository SkillRepository { get; }
        ITraitRepository TraitRepository { get; }
    }
}
