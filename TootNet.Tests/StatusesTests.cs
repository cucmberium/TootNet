using System;
using System.Threading.Tasks;
using TootNet.Exception;
using Xunit;

namespace TootNet.Tests
{
    public class StatusesTests
    {
        [Fact]
        public async Task PostAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var toot = await tokens.Statuses.PostAsync(status => "test toot", visibility => "private");

            Assert.NotNull(toot);
            Assert.Equal("<p>test toot</p>", toot.Content);
        }

        [Fact]
        public async Task IdAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var status = await tokens.Statuses.IdAsync(id => 111155004820251442);

            Assert.NotNull(status);
            Assert.Equal("tootnet", status.Account.Acct);
            Assert.Equal("tootnet", status.Account.UserName);
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
                var status = await tokens.Statuses.IdAsync(id => toot.Id);
            }
            catch (MastodonException e)
            {
                return;
            }

            throw new InvalidOperationException();
        }

        [Fact]
        public async Task ContextAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var context = await tokens.Statuses.ContextAsync(id => 111155004820251442);

            Assert.NotNull(context);
            Assert.NotNull(context.Ancestors);
            Assert.NotNull(context.Descendants);
        }

        [Fact]
        public async Task TranslateAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var translation = await tokens.Statuses.TranslateAsync(id => 111155004820251442, lang => "ja");

            Assert.NotNull(translation);
            Assert.NotNull(translation.Content);
            Assert.NotNull(translation.DetectedSourceLanguage);
        }

        [Fact]
        public async Task RebloggedByAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var accounts = await tokens.Statuses.RebloggedByAsync(id => 111817004833475272);

            Assert.NotNull(accounts);
            Assert.NotEmpty(accounts);
        }

        [Fact]
        public async Task FavouritedByAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var accounts = await tokens.Statuses.FavouritedByAsync(id => 111817004833475272);

            Assert.NotNull(accounts);
            Assert.NotEmpty(accounts);
        }

        [Fact]
        public async Task ReblogAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
            
            var status = await tokens.Statuses.IdAsync(id => 111155004820251442);

            await Task.Delay(1000);

            if (status.Reblogged == true)
                await tokens.Statuses.UnreblogAsync(id => 111155004820251442);

            await Task.Delay(1000);

            var reblogedStatus = await tokens.Statuses.ReblogAsync(id => 111155004820251442);

            Assert.True(reblogedStatus.Reblogged);
            
            await Task.Delay(1000);

            await tokens.Statuses.UnreblogAsync(id => 111155004820251442);
        }

        [Fact]
        public async Task UnreblogAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var status = await tokens.Statuses.IdAsync(id => 111155004820251442);

            await Task.Delay(1000);

            if (status.Reblogged == false || status.Reblogged == null)
                await tokens.Statuses.ReblogAsync(id => 111155004820251442);

            await Task.Delay(1000);

            var reblogedStatus = await tokens.Statuses.UnreblogAsync(id => 111155004820251442);

            Assert.False(reblogedStatus.Reblogged);
        }

        [Fact]
        public async Task MuteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var status = await tokens.Statuses.IdAsync(id => 111155004820251442);

            await Task.Delay(1000);

            if (status.Muted == true)
                await tokens.Statuses.UnmuteAsync(id => 111155004820251442);

            await Task.Delay(1000);

            var mutedStatus = await tokens.Statuses.MuteAsync(id => 111155004820251442);

            Assert.True(mutedStatus.Muted);

            await Task.Delay(1000);

            await tokens.Statuses.UnmuteAsync(id => 111155004820251442);
        }

        [Fact]
        public async Task UnmuteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var status = await tokens.Statuses.IdAsync(id => 111155004820251442);

            await Task.Delay(1000);

            if (status.Muted == false || status.Muted == null)
                await tokens.Statuses.MuteAsync(id => 111155004820251442);

            await Task.Delay(1000);

            var mutedStatus = await tokens.Statuses.UnmuteAsync(id => 111155004820251442);

            Assert.False(mutedStatus.Muted);
        }

        [Fact]
        public async Task PinAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            await tokens.Statuses.PinAsync(id => 111155004820251442);

            await Task.Delay(1000);

            await tokens.Statuses.UnpinAsync(id => 111155004820251442);
        }

        [Fact]
        public async Task UnpinAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            await tokens.Statuses.PinAsync(id => 111155004820251442);

            await Task.Delay(1000);

            await tokens.Statuses.UnpinAsync(id => 111155004820251442);
        }

        [Fact]
        public async Task PutAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var toot = await tokens.Statuses.PostAsync(status => "test toot", visibility => "private");

            await Task.Delay(1000);

            var editedToot = await tokens.Statuses.PutAsync(id => toot.Id, status => "test toot edited");

            Assert.NotNull(editedToot);
            Assert.Equal("<p>test toot edited</p>", editedToot.Content);
        }

        [Fact]
        public async Task HistoryAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var toot = await tokens.Statuses.PostAsync(status => "test toot", visibility => "private");

            await Task.Delay(1000);

            var editedToot = await tokens.Statuses.PutAsync(id => toot.Id, status => "test toot edited");

            await Task.Delay(1000);

            var histories = await tokens.Statuses.HistoryAsync(id => editedToot.Id);

            Assert.Equal(2, histories.Count);
        }

        [Fact]
        public async Task SourceAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var toot = await tokens.Statuses.PostAsync(status => "test toot", visibility => "private");

            await Task.Delay(1000);

            var source = await tokens.Statuses.SourceAsync(id => toot.Id);

            Assert.Equal("test toot", source.Text);
        }
    }
}
