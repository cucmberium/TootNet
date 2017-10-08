using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TootNet.Exception;
using Xunit;

namespace TootNet.Tests
{
    public class StatusesTests
    {
        [Fact]
        public async Task IdAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var status = await tokens.Statuses.IdAsync(id => 4450025);

            Assert.NotNull(status);
            Assert.Equal(status.Content, "<p>a</p>");
            Assert.Equal(status.Url, "https://mstdn.jp/@cucmberium/4450025");
            Assert.Equal(status.Account.Acct, "cucmberium");
            Assert.Equal(status.Account.UserName, "cucmberium");
            Assert.Equal(status.Account.Url, "https://mstdn.jp/@cucmberium");
        }

        [Fact]
        public async Task ContextAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var context = await tokens.Statuses.ContextAsync(id => 4450025);

            Assert.NotNull(context);
            Assert.NotNull(context.Ancestors);
            Assert.NotNull(context.Descendants);
        }

        [Fact]
        public async Task CardAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var card = await tokens.Statuses.CardAsync(id => 4450025);

            Assert.NotNull(card);
        }

        [Fact]
        public async Task RebloggedByAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var accounts = await tokens.Statuses.RebloggedByAsync(id => 948164);

            Assert.NotNull(accounts);
            Assert.True(accounts.Count > 0);
        }

        [Fact]
        public async Task FavouritedByAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var accounts = await tokens.Statuses.FavouritedByAsync(id => 948164);

            Assert.NotNull(accounts);
            Assert.True(accounts.Count > 0);
        }

        [Fact]
        public async Task PostAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var toot = await tokens.Statuses.PostAsync(status => "test toot", visibility => "private");

            Assert.NotNull(toot);
            Assert.Equal(toot.Content, "<p>test toot</p>");
        }

        [Fact]
        public async Task DeleteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var toot = await tokens.Statuses.PostAsync(status => "test toot for delete", visibility => "private");

            await Task.Delay(1000);

            await tokens.Statuses.DeleteAsync(id => toot.Id);

            await Task.Delay(1000);

            try
            {
                await tokens.Statuses.IdAsync(id => toot.Id);
            }
            catch (MastodonException e)
            {
                return;
            }

            throw new InvalidOperationException();
        }

        [Fact]
        public async Task ReblogAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
            
            var status = await tokens.Statuses.IdAsync(id => 45720257);

            await Task.Delay(1000);

            if (status.Reblogged == true)
                await tokens.Statuses.UnreblogAsync(id => 45720257);

            await Task.Delay(1000);

            var reblogedStatus = await tokens.Statuses.ReblogAsync(id => 45720257);

            Assert.True(reblogedStatus.Reblogged);
            
            await Task.Delay(1000);

            await tokens.Statuses.UnreblogAsync(id => 45720257);
        }

        [Fact]
        public async Task UnreblogAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var status = await tokens.Statuses.IdAsync(id => 45720257);

            await Task.Delay(1000);

            if (status.Reblogged == false || status.Reblogged == null)
                await tokens.Statuses.ReblogAsync(id => 45720257);

            await Task.Delay(1000);

            var reblogedStatus = await tokens.Statuses.UnreblogAsync(id => 45720257);

            Assert.False(reblogedStatus.Reblogged);
        }

        [Fact]
        public async Task FavouriteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var status = await tokens.Statuses.IdAsync(id => 45720257);

            await Task.Delay(1000);

            if (status.Favourited == true)
                await tokens.Statuses.UnfavouriteAsync(id => 45720257);

            await Task.Delay(1000);

            var reblogedStatus = await tokens.Statuses.FavouriteAsync(id => 45720257);

            Assert.True(reblogedStatus.Favourited);


            await Task.Delay(1000);

            await tokens.Statuses.UnfavouriteAsync(id => 45720257);
        }

        [Fact]
        public async Task UnfavouriteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var status = await tokens.Statuses.IdAsync(id => 45720257);

            await Task.Delay(1000);

            if (status.Favourited == false || status.Favourited == null)
                await tokens.Statuses.FavouriteAsync(id => 45720257);


            await Task.Delay(1000);

            var reblogedStatus = await tokens.Statuses.UnfavouriteAsync(id => 45720257);

            Assert.False(reblogedStatus.Favourited);
        }

        [Fact]
        public async Task MuteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var status = await tokens.Statuses.IdAsync(id => 45720257);
            
            await Task.Delay(1000);

            if (status.Muted == true)
                await tokens.Statuses.UnmuteAsync(id => 45720257);

            await Task.Delay(1000);

            var reblogedStatus = await tokens.Statuses.MuteAsync(id => 45720257);

            Assert.True(reblogedStatus.Muted);

            await Task.Delay(1000);

            await tokens.Statuses.UnmuteAsync(id => 45720257);
        }

        [Fact]
        public async Task UnmuteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var status = await tokens.Statuses.IdAsync(id => 45720257);

            await Task.Delay(1000);

            if (status.Muted == false || status.Muted == null)
                await tokens.Statuses.MuteAsync(id => 45720257);

            await Task.Delay(1000);

            var reblogedStatus = await tokens.Statuses.UnmuteAsync(id => 45720257);

            Assert.False(reblogedStatus.Muted);
        }
    }
}
