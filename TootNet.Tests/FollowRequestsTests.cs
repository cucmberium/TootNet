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

            var accounts = await tokens.FollowRequests.AuthorizeAsync(account_id => 13179);

            Assert.NotNull(accounts);
        }

        [Fact]
        public async Task RejectAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var accounts = await tokens.FollowRequests.RejectAsync(account_id => 13179);

            Assert.NotNull(accounts);
        }
    }
}
