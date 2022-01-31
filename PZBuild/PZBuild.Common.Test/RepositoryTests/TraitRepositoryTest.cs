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
    public class TraitRepositoryTest
    {
        public readonly ITraitRepository _repository;
        public readonly PZBuildContext _context;

        public TraitRepositoryTest()
        {
            ILogger<TraitRepository> logger = new LoggerFactory().CreateLogger<TraitRepository>();

            SqliteConnection connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            DbContextOptions<PZBuildContext>? options = new DbContextOptionsBuilder<PZBuildContext>().UseSqlite(connection).Options;

            _context = new PZBuildContext(options);
            _context.Database.EnsureCreated();

            _repository = new TraitRepository(logger, _context);
        }

        [Fact]
        public async Task TraitRepository_CreateMany_Success()
        {
            /*  JavaScript - Target: https://pzwiki.net/wiki/Traits
                
                var collection = [];
                $("#mw-content-text > div > div > div > table > tbody > tr").each(function (index, e) {
                    var skip = [0, 1];
                    if (!skip.includes(index)) {
                        var cols = $(e).find("td");
                        collection.push({
                            Name: $(cols[1]).text().trim(),
                            Icon: "https://" + location.hostname + $(cols[0]).find("img").attr("src"),
                            IsOccupationExclusive: false,
                            IsPositive: $(cols[2]).text() === "Positive",
                            Point: parseInt($(cols[4]).text()),
                            Description: $(cols[5]).text().replaceAll('"', ''),
                            Effect: $(cols[6]).text().replace(/(\r\n|\n|\r)/gm,"")
                        });
                    }
                });
                JSON.stringify(collection);
                
            */

            string json = File.ReadAllText("MockData/traits.json");

            List<Trait> traits = JsonConvert.DeserializeObject<List<Trait>>(json);
            traits.ForEach(trait => trait.TraitGuid = Guid.NewGuid());

            await _repository.CreateTraits(traits);
            await _repository.Save();

            Assert.True(_context.Traits
                .Any(existing => traits
                    .Select(trait => trait.TraitID)
                    .Contains(existing.TraitID)));
        }
    }
}