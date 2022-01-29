using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PZBuild.Common.Data;
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
            using PZBuildContext context = new PZBuildContext(options);
            Assert.True(await context.Database.EnsureCreatedAsync());
        }
    }
}