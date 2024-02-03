using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class ReportsTests
    {
        [Fact(Skip = "WIP")]
        public async Task PostAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var report = await tokens.Reports.PostAsync(account_id => 13179);

            Assert.NotNull(report);
        }
    }
}
