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

namespace PZBuild.Common.Test.RepositoryTests
{
    public class SkillRepositoryTest
    {
        public readonly ISkillRepository _repository;
        public readonly PZBuildContext _context;

        public SkillRepositoryTest()
        {
            ILogger<SkillRepository> logger = new LoggerFactory().CreateLogger<SkillRepository>();

            SqliteConnection connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            DbContextOptions<PZBuildContext>? options = new DbContextOptionsBuilder<PZBuildContext>().UseSqlite(connection).Options;

            _context = new PZBuildContext(options);
            _context.Database.EnsureCreated();

            _repository = new SkillRepository(logger, _context);
        }

        [Fact]
        public async Task SkillRepository_CreateMany_Success()
        {
            string json = File.ReadAllText("MockData/skills.json");

            List<Skill> skills = JsonConvert.DeserializeObject<List<Skill>>(json);
            skills.ForEach(skill => skill.SkillGuid = Guid.NewGuid());

            await _repository.CreateSkills(skills);
            await _repository.Save();

            Assert.True(_context.Skills
                .Any(existing => skills
                    .Select(skill => skill.SkillID)
                    .Contains(existing.SkillID)));
        }
    }
}