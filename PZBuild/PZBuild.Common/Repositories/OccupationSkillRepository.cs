using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PZBuild.Common.Data;
using PZBuild.Common.Models;
using PZBuild.Common.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PZBuild.Common.Repositories
{
    public class OccupationSkillRepository : IOccupationSkillRepository
    {
        public readonly ILogger<OccupationSkillRepository> _logger;
        public readonly PZBuildContext _context;

        public OccupationSkillRepository(ILogger<OccupationSkillRepository> logger, PZBuildContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task CreateOccupationSkill(OccupationSkill occupationSkill) => await _context.OccupationSkills.AddAsync(occupationSkill);

        public async Task CreateOccupationSkills(List<OccupationSkill> occupationSkills) => await _context.OccupationSkills.AddRangeAsync(occupationSkills);

        public void UpdateOccupationSkill(OccupationSkill occupationSkill) => _context.OccupationSkills.Update(occupationSkill);

        public void UpdateOccupationSkills(List<OccupationSkill> occupationSkills) => _context.OccupationSkills.UpdateRange(occupationSkills);

        public async Task<OccupationSkill?> ReadOccupationSkill(int id) => await _context.OccupationSkills.FindAsync(id);

        public async Task<List<OccupationSkill>> ReadOccupationSkills() => await _context.OccupationSkills.ToListAsync();

        public void DeleteOccupationSkill(OccupationSkill occupationSkill) => _context.OccupationSkills.Remove(occupationSkill);

        public void DeleteOccupationSkills(List<OccupationSkill> occupationSkills) => _context.OccupationSkills.RemoveRange(occupationSkills);

        public async Task Save() => await _context.SaveChangesAsync();

        
    }
}
