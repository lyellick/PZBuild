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
    public class SkillRepository : ISkillRepository
    {
        public readonly ILogger<SkillRepository> _logger;
        public readonly PZBuildContext _context;

        public SkillRepository(ILogger<SkillRepository> logger, PZBuildContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task CreateSkill(Skill skill) => await _context.Skills.AddAsync(skill);

        public async Task CreateSkills(List<Skill> skills) => await _context.Skills.AddRangeAsync(skills);

        public void UpdateSkill(Skill skill) => _context.Skills.Update(skill);

        public void UpdateSkills(List<Skill> skills) => _context.Skills.UpdateRange(skills);

        public async Task<Skill?> ReadSkill(int id) => await _context.Skills.FindAsync(id);

        public async Task<List<Skill>> ReadSkills() => await _context.Skills.ToListAsync();

        public void DeleteSkill(Skill skill) => _context.Skills.Remove(skill);

        public void DeleteSkills(List<Skill> skills) => _context.Skills.RemoveRange(skills);

        public async Task Save() => await _context.SaveChangesAsync();

        
    }
}
