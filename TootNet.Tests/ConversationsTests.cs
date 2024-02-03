using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class ConversationsTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            await tokens.Statuses.PostAsync(status => "@cucmberium@mstdn.maud.io test", visibility => "direct");

            await Task.Delay(1000);

            var conversations = await tokens.Conversations.GetAsync();

            Assert.NotEmpty(conversations);

            await Task.Delay(1000);

            await tokens.Conversations.DeleteAsync(id => conversations.First().Id);
        }

        [Fact]
        public async Task DeleteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            await tokens.Statuses.PostAsync(status => "@cucmberium@mstdn.maud.io test", visibility => "direct");

            await Task.Delay(1000);

            var oldConversations = await tokens.Conversations.GetAsync();

            await Task.Delay(1000);

            await tokens.Conversations.DeleteAsync(id => oldConversations.First().Id);

            await Task.Delay(1000);

            var newConversations = await tokens.Conversations.GetAsync();

            Assert.DoesNotContain(newConversations, conversation => conversation.Id == oldConversations.First().Id);

        }

        [Fact]
        public async Task ReadAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            await tokens.Statuses.PostAsync(status => "@cucmberium@mstdn.maud.io test", visibility => "direct");

            await Task.Delay(1000);

            var oldConversations = await tokens.Conversations.GetAsync();

            await Task.Delay(1000);

            await tokens.Conversations.ReadAsync(id => oldConversations.First().Id);

            await Task.Delay(1000);

            var newConversations = await tokens.Conversations.GetAsync();

            Assert.False(newConversations.First().Unread);
        }
    }
}
