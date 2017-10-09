using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class FollowRequestsTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var accounts = await tokens.FollowRequests.GetAsync(limit => 10);

            Assert.NotNull(accounts);
        }

        [Fact]
        public async Task AuthorizeAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
        }

        [Fact]
        public async Task RejectAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
        }
    }
}
