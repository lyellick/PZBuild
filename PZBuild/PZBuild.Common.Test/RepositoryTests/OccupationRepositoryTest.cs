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
    public class OccupationRepositoryTest
    {
        public readonly IOccupationRepository _repository;
        public readonly PZBuildContext _context;

        public OccupationRepositoryTest()
        {
            ILogger<OccupationRepository> logger = new LoggerFactory().CreateLogger<OccupationRepository>();

            SqliteConnection connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            DbContextOptions<PZBuildContext>? options = new DbContextOptionsBuilder<PZBuildContext>().UseSqlite(connection).Options;

            _context = new PZBuildContext(options);
            _context.Database.EnsureCreated();

            _repository = new OccupationRepository(logger, _context);
        }

        [Fact]
        public async Task OccupationRepository_CreateMany_Success()
        {
            /*  JavaScript - Target: https://pzwiki.net/wiki/Occupation
                
                var collection = [];
                $("#mw-content-text > div > div > div > table > tbody > tr").each(function (index, e) {
                    var cols = $(e).find("td");
                    collection.push({
                        Name: $(cols[0]).text().trim(),
                        Icon: "https://" + location.hostname + $(cols[0]).find("img").attr("src"),
                        Description: $(cols[4]).text().replaceAll('"', '')
                    });
                });
                JSON.stringify(collection);
                
            */

            string json = File.ReadAllText("MockData/occupations.json");

            List<Occupation> occupations = JsonConvert.DeserializeObject<List<Occupation>>(json);
            occupations.ForEach(occupation => occupation.OccupationGuid = Guid.NewGuid());

            await _repository.CreateOccupations(occupations);
            await _repository.Save();

            Assert.True(_context.Occupations
                .Any(existing => occupations
                    .Select(occupation => occupation.OccupationID)
                    .Contains(existing.OccupationID)));
        }
    }
}