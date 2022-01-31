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
    public class OccupationRepository : IOccupationRepository
    {
        public readonly ILogger<OccupationRepository> _logger;
        public readonly PZBuildContext _context;

        public OccupationRepository(ILogger<OccupationRepository> logger, PZBuildContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task CreateOccupation(Occupation occupation) => await _context.Occupations.AddAsync(occupation);

        public async Task CreateOccupations(List<Occupation> occupations) => await _context.Occupations.AddRangeAsync(occupations);

        public void UpdateOccupation(Occupation occupation) => _context.Occupations.Update(occupation);

        public void UpdateOccupations(List<Occupation> occupations) => _context.Occupations.UpdateRange(occupations);

        public async Task<Occupation?> ReadOccupation(int id) => await _context.Occupations.FindAsync(id);

        public async Task<List<Occupation>> ReadOccupations() => await _context.Occupations.ToListAsync();

        public void DeleteOccupation(Occupation occupation) => _context.Occupations.Remove(occupation);

        public void DeleteOccupations(List<Occupation> occupations) => _context.Occupations.RemoveRange(occupations);

        public async Task Save() => await _context.SaveChangesAsync();

        
    }
}
