using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class ReportsTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var reports = await tokens.Reports.GetAsync();

            Assert.NotNull(reports);
        }

        [Fact]
        public async Task PostAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
        }
    }
}
