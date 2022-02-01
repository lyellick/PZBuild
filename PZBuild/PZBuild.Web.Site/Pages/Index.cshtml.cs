using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PZBuild.Common.Models;
using PZBuild.Common.Repositories.IRepositories;
using PZBuild.Common.Services.IServices;

namespace PZBuild.Web.Site.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPZBuildService _pzBuildService;

        public IndexModel(ILogger<IndexModel> logger, IPZBuildService pzBuildService)
        {
            _logger = logger;
            _pzBuildService = pzBuildService;
        }
        public Occupation? SelectedOccupation { get; set; } = null;
        public List<Trait> SelectedTraits { get; set; } = new List<Trait>();

        public List<Occupation> Occupations { get; private set; }
        public List<Skill> Skills { get; private set; }
        public List<Trait> Traits { get; private set; }

        public async Task OnGetAsync(string occupation, string traits)
        {
            Occupations = await _pzBuildService.OccupationRepository.ReadOccupations();
            Skills = await _pzBuildService.SkillRepository.ReadSkills();
            Traits = await _pzBuildService.TraitRepository.ReadTraits();

            if (!string.IsNullOrEmpty(occupation))
                SelectedOccupation = Occupations.FirstOrDefault(x => x.Name.ToLower().Equals(occupation.ToLower()));

            if (!string.IsNullOrEmpty(occupation) && !string.IsNullOrEmpty(traits))
                SelectedTraits = Traits.Where(x => traits.Split(",").Select(x => x.ToLower()).Contains(x.Name.ToLower()) && !x.IsOccupationExclusive).ToList();
        }
    }
}