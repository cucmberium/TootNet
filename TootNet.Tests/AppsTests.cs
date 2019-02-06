using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class AppsTests
    {
        [Fact]
        public async Task PostAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
        }

        [Fact]
        public async Task VerifyCredentialsAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var app = await tokens.Apps.VerifyCredentialsAsync();

            Assert.NotNull(app.ClientId);
            Assert.NotNull(app.ClientSecret);
        }
    }
}
