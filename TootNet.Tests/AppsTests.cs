using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class AppsTests
    {
        [Fact]
        public async Task VerifyCredentialsAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var app = await tokens.Apps.VerifyCredentialsAsync();

            Assert.NotNull(app.Name);
        }
    }
}
