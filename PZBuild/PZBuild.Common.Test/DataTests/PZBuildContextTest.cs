using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PZBuild.Common.Data;
using System.Threading.Tasks;
using Xunit;

namespace PZBuild.Common.Test.DataTests
{
    public class PZBuildContextTest
    {
        private readonly PZBuildContext _context;

        public PZBuildContextTest()
        {
            using SqliteConnection connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            DbContextOptions<PZBuildContext>? options = new DbContextOptionsBuilder<PZBuildContext>().UseSqlite(connection).Options;
            _context = new PZBuildContext(options);
        }

        [Fact]
        public async Task PZBuildContext_UsingSqliteInMemoryProvider_EnsureCreatedAsync()
        {
            Assert.True(await _context.Database.EnsureCreatedAsync());
        }
    }
}