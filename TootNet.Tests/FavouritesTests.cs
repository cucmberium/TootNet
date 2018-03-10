using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class FavouritesTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var statuses = await tokens.Favourites.GetAsync(limit => 10);

            Assert.Equal(10, statuses.Count);
            foreach (var status in statuses)
            {
                Assert.NotNull(status.Account.Acct);
                Assert.NotNull(status.Account.UserName);
                Assert.NotNull(status.Account.Url);
                Assert.NotNull(status.Content);
            }
        }
    }
}
