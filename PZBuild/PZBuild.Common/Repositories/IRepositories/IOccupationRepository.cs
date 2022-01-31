using PZBuild.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZBuild.Common.Repositories.IRepositories
{
    public interface IOccupationRepository
    {
        Task CreateOccupation(Occupation occupation);

        Task CreateOccupations(List<Occupation> occupations);

        void UpdateOccupation(Occupation occupation);

        void UpdateOccupations(List<Occupation> occupations);

        Task<Occupation?> ReadOccupation(int id);

        Task<List<Occupation>> ReadOccupations();

        void DeleteOccupation(Occupation occupation);

        void DeleteOccupations(List<Occupation> occupations);

        Task Save();
    }
}
