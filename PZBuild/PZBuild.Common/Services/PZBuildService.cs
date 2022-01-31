using Microsoft.Extensions.Logging;
using PZBuild.Common.Repositories.IRepositories;
using PZBuild.Common.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZBuild.Common.Services
{
    public class PZBuildService : IPZBuildService
    {
        public readonly ILogger<PZBuildService> _logger;
        public readonly IOccupationRepository _occupationRepository;
        public readonly IOccupationSkillRepository _occupationSkillRepository;
        public readonly ISkillRepository _skillRepository;
        public readonly ITraitRepository _traitRepository;

        public PZBuildService(ILogger<PZBuildService> logger, IOccupationRepository occupationRepository, IOccupationSkillRepository occupationSkillRepository, ISkillRepository skillRepository, ITraitRepository traitRepository)
        {
            _logger = logger;
            _occupationRepository = occupationRepository;
            _occupationSkillRepository = occupationSkillRepository;
            _skillRepository = skillRepository;
            _traitRepository = traitRepository;
        }

        public IOccupationRepository OccupationRepository => _occupationRepository;

        public IOccupationSkillRepository OccupationSkillRepository => _occupationSkillRepository;

        public ISkillRepository SkillRepository => _skillRepository;

        public ITraitRepository TraitRepository => _traitRepository;
    }
}
