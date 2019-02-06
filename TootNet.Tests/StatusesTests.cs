using System;
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
            Assert.Equal("<p>a</p>", status.Content);
            Assert.Equal("https://mstdn.jp/@cucmberium/4450025", status.Url);
            Assert.Equal("cucmberium", status.Account.Acct);
            Assert.Equal("cucmberium", status.Account.UserName);
            Assert.Equal("https://mstdn.jp/@cucmberium", status.Account.Url);
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
            Assert.Equal("<p>test toot</p>", toot.Content);
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
        public async Task PinAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            await tokens.Statuses.PinAsync(id => 45720257);

            await Task.Delay(1000);

            await tokens.Statuses.UnpinAsync(id => 45720257);
        }

        [Fact]
        public async Task UnpinAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            await tokens.Statuses.PinAsync(id => 45720257);

            await Task.Delay(1000);

            await tokens.Statuses.UnpinAsync(id => 45720257);
        }
    }
}
