using System.Collections.Generic;
using System.Linq;
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

            Assert.Equal(account.Acct, "cucmberium@pawoo.net");
            Assert.Equal(account.UserName, "cucmberium");
            Assert.NotNull(account.Url);

            await tokens.Accounts.UnfollowAsync(id => account.Id);
        }
    }
}
