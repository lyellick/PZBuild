using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PZBuild.Common.Data;
using PZBuild.Common.Models;
using PZBuild.Common.Repositories;
using PZBuild.Common.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PZBuild.Common.Test.DataTests
{
    public class PZBuildContextTest
    {
        [Fact]
        public async Task PZBuildContext_UsingSqliteInMemoryProvider_EnsureCreatedAsync()
        {
            using SqliteConnection connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            DbContextOptions<PZBuildContext>? options = new DbContextOptionsBuilder<PZBuildContext>().UseSqlite(connection).Options;
            PZBuildContext context = new PZBuildContext(options);

            Assert.True(await context.Database.EnsureCreatedAsync());
        }

        [Fact]
        public async Task PZBuildContext_UsingSQLServerProvider_HasData()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Database=PZBuild;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
            DbContextOptions<PZBuildContext>? options = new DbContextOptionsBuilder<PZBuildContext>().UseSqlServer(connectionString).Options;
            PZBuildContext context = new PZBuildContext(options);

            bool hasOccupations = context.Occupations.Any();
            bool hasSkills = context.Skills.Any();
            bool hasTraits = context.Traits.Any();

            if (!hasOccupations)
            {
                string occupationsJson = File.ReadAllText("MockData/occupations.json");

                List<Occupation> occupations = JsonConvert.DeserializeObject<List<Occupation>>(occupationsJson);
                occupations.ForEach(occupation => occupation.OccupationGuid = Guid.NewGuid());

                await context.Occupations.AddRangeAsync(occupations);
                await context.SaveChangesAsync();

                hasOccupations = true;
            }

            if (!hasSkills)
            {
                string skillsJson = File.ReadAllText("MockData/skills.json");

                List<Skill> skills = JsonConvert.DeserializeObject<List<Skill>>(skillsJson);
                skills.ForEach(skill => skill.SkillGuid = Guid.NewGuid());

                await context.Skills.AddRangeAsync(skills);
                await context.SaveChangesAsync();

                hasSkills = true;
            }

            if (!hasTraits)
            {
                string traitsJson = File.ReadAllText("MockData/traits.json");

                List<Trait> traits = JsonConvert.DeserializeObject<List<Trait>>(traitsJson);
                traits.ForEach(trait => trait.TraitGuid = Guid.NewGuid());

                await context.Traits.AddRangeAsync(traits);
                await context.SaveChangesAsync();

                hasTraits = true;
            }

            Assert.True(hasOccupations && hasTraits && hasSkills);
        }
    }
}