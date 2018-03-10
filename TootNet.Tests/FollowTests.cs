using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class FollowTests
    {
        [Fact]
        public async Task PostAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var account = await tokens.Follows.PostAsync(uri => "cucmberium@pawoo.net");

            Assert.Equal("cucmberium@pawoo.net", account.Acct);
            Assert.Equal("cucmberium", account.UserName);
            Assert.NotNull(account.Url);

            await tokens.Accounts.UnfollowAsync(id => account.Id);
        }
    }
}
