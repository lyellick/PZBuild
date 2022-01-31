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
    public class TraitRepository : ITraitRepository
    {
        public readonly ILogger<TraitRepository> _logger;
        public readonly PZBuildContext _context;

        public TraitRepository(ILogger<TraitRepository> logger, PZBuildContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task CreateTrait(Trait trait) => await _context.Traits.AddAsync(trait);

        public async Task CreateTraits(List<Trait> traits) => await _context.Traits.AddRangeAsync(traits);

        public void UpdateTrait(Trait trait) => _context.Traits.Update(trait);

        public void UpdateTraits(List<Trait> traits) => _context.Traits.UpdateRange(traits);

        public async Task<Trait?> ReadTrait(int id) => await _context.Traits.FindAsync(id);

        public async Task<List<Trait>> ReadTraits() => await _context.Traits.ToListAsync();

        public void DeleteTrait(Trait trait) => _context.Traits.Remove(trait);

        public void DeleteTraits(List<Trait> traits) => _context.Traits.RemoveRange(traits);

        public async Task Save() => await _context.SaveChangesAsync();

        
    }
}
