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

            var statuses = await tokens.Favourites.GetAsync(limit => 1);

            Assert.Single(statuses);
            foreach (var status in statuses)
            {
                Assert.NotNull(status.Account.Acct);
                Assert.NotNull(status.Account.UserName);
                Assert.NotNull(status.Account.Url);
                Assert.NotNull(status.Content);
            }
        }

        [Fact]
        public async Task FavouriteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var status = await tokens.Statuses.IdAsync(id => 111031128530593092);

            await Task.Delay(1000);

            if (status.Favourited == true)
                await tokens.Favourites.UnfavouriteAsync(id => 111031128530593092);

            await Task.Delay(1000);

            var favoritedStatus = await tokens.Favourites.FavouriteAsync(id => 111031128530593092);

            Assert.True(favoritedStatus.Favourited);

            await Task.Delay(1000);

            await tokens.Favourites.UnfavouriteAsync(id => 111031128530593092);
        }

        [Fact]
        public async Task UnfavouriteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var status = await tokens.Statuses.IdAsync(id => 111031128530593092);

            await Task.Delay(1000);

            if (status.Favourited is false or null)
                await tokens.Favourites.FavouriteAsync(id => 111031128530593092);

            await Task.Delay(1000);

            var favoritedStatus = await tokens.Favourites.UnfavouriteAsync(id => 111031128530593092);

            Assert.False(favoritedStatus.Favourited);
        }
    }
}
