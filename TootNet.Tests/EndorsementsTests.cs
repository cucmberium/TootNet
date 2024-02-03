using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class EndorsementsTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            await tokens.Accounts.FollowAsync(id => 13179);

            await Task.Delay(1000);

            await tokens.Endorsements.PinAsync(id => 13179);

            await Task.Delay(1000);

            var endorsements = await tokens.Endorsements.GetAsync();

            Assert.NotEmpty(endorsements);
            Assert.Contains(endorsements, x => x.Acct == "Mastodon");

            await Task.Delay(1000);

            await tokens.Endorsements.UnpinAsync(id => 13179);

            await Task.Delay(1000);

            await tokens.Accounts.UnfollowAsync(id => 13179);
        }

        [Fact]
        public async Task PinAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            await tokens.Accounts.FollowAsync(id => 13179);

            await Task.Delay(1000);

            await tokens.Endorsements.PinAsync(id => 13179);

            await Task.Delay(1000);

            var endorsements = await tokens.Endorsements.GetAsync();

            Assert.NotEmpty(endorsements);
            Assert.Contains(endorsements, x => x.Acct == "Mastodon");

            await Task.Delay(1000);

            await tokens.Endorsements.UnpinAsync(id => 13179);

            await Task.Delay(1000);

            await tokens.Accounts.UnfollowAsync(id => 13179);
        }

        [Fact]
        public async Task UnpinAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            await tokens.Accounts.FollowAsync(id => 13179);

            await Task.Delay(1000);

            await tokens.Endorsements.PinAsync(id => 13179);

            await Task.Delay(1000);

            await tokens.Endorsements.UnpinAsync(id => 13179);

            await Task.Delay(1000);

            var endorsements = await tokens.Endorsements.GetAsync();

            Assert.DoesNotContain(endorsements, x => x.Acct == "Mastodon");

            await Task.Delay(1000);

            await tokens.Accounts.UnfollowAsync(id => 13179);
        }
    }
}
