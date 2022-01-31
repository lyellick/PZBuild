using PZBuild.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZBuild.Common.Repositories.IRepositories
{
    public interface ITraitRepository
    {
        Task CreateTrait(Trait trait);

        Task CreateTraits(List<Trait> traits);

        void UpdateTrait(Trait trait);

        void UpdateTraits(List<Trait> traits);

        Task<Trait?> ReadTrait(int id);

        Task<List<Trait>> ReadTraits();

        void DeleteTrait(Trait trait);

        void DeleteTraits(List<Trait> traits);

        Task Save();
    }
}
