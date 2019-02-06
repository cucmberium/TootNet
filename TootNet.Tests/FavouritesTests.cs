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

        [Fact]
        public async Task FavouriteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var status = await tokens.Statuses.IdAsync(id => 45720257);

            await Task.Delay(1000);

            if (status.Favourited == true)
                await tokens.Favourites.UnfavouriteAsync(id => 45720257);

            await Task.Delay(1000);

            var reblogedStatus = await tokens.Favourites.FavouriteAsync(id => 45720257);

            Assert.True(reblogedStatus.Favourited);


            await Task.Delay(1000);

            await tokens.Favourites.UnfavouriteAsync(id => 45720257);
        }

        [Fact]
        public async Task UnfavouriteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var status = await tokens.Statuses.IdAsync(id => 45720257);

            await Task.Delay(1000);

            if (status.Favourited == false || status.Favourited == null)
                await tokens.Favourites.FavouriteAsync(id => 45720257);


            await Task.Delay(1000);

            var reblogedStatus = await tokens.Favourites.UnfavouriteAsync(id => 45720257);

            Assert.False(reblogedStatus.Favourited);
        }
    }
}
