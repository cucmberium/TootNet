using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class AccountTests
    {
        [Fact]
        public async Task IdAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var account = await tokens.Accounts.IdAsync(id => 12447);

            Assert.NotNull(account.Acct);
            Assert.NotNull(account.UserName);
            Assert.NotNull(account.Url);
        }

        [Fact]
        public async Task VerifyCredentialsAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var account = await tokens.Accounts.VerifyCredentialsAsync();

            Assert.NotNull(account.Acct);
            Assert.NotNull(account.UserName);
            Assert.NotNull(account.Url);
        }

        [Fact]
        public async Task UpdateCredentialsAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldaccount = await tokens.Accounts.VerifyCredentialsAsync();

            await Task.Delay(1000);

            var newaccount = await tokens.Accounts.UpdateCredentialsAsync(display_name => "test");

            Assert.NotNull(newaccount.Acct);
            Assert.NotNull(newaccount.UserName);
            Assert.NotNull(newaccount.Url);
            Assert.Equal(newaccount.DisplayName, "test");

            await Task.Delay(1000);

            await tokens.Accounts.UpdateCredentialsAsync(display_name => oldaccount.DisplayName);
        }

        [Fact]
        public async Task FollowersAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var accounts = await tokens.Accounts.FollowersAsync(id => 12447, limit => 10);

            Assert.Equal(accounts.Count, 10);
            foreach (var account in accounts)
            {
                Assert.NotNull(account.Acct);
                Assert.NotNull(account.UserName);
                Assert.NotNull(account.Url);
            }
        }

        [Fact]
        public async Task FollowingAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var accounts = await tokens.Accounts.FollowingAsync(id => 12447, limit => 10);

            Assert.Equal(accounts.Count, 10);
            foreach (var account in accounts)
            {
                Assert.NotNull(account.Acct);
                Assert.NotNull(account.UserName);
                Assert.NotNull(account.Url);
            }
        }

        [Fact]
        public async Task StatusesAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var statuses = await tokens.Accounts.StatusesAsync(id => 12447, limit => 10);

            Assert.Equal(statuses.Count, 10);
            foreach (var status in statuses)
            {
                Assert.NotNull(status.Account.Acct);
                Assert.NotNull(status.Account.UserName);
                Assert.NotNull(status.Account.Url);
                Assert.NotNull(status.Content);
            }
        }

        [Fact]
        public async Task FollowAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldrelationship = (await tokens.Accounts.RelationshipsAsync(id => new List<long> { 32641 })).First();
            await Task.Delay(1000);

            if (oldrelationship.Following)
                await tokens.Accounts.UnfollowAsync(id => 32641);

            await Task.Delay(1000);

            var relationship = await tokens.Accounts.FollowAsync(id => 32641);

            Assert.True(relationship.Following);
        }

        [Fact]
        public async Task UnfollowAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldrelationship = (await tokens.Accounts.RelationshipsAsync(id => new List<long> { 32641 })).First();
            await Task.Delay(1000);

            if (!oldrelationship.Following)
                await tokens.Accounts.FollowAsync(id => 32641);

            await Task.Delay(1000);

            var relationship = await tokens.Accounts.UnfollowAsync(id => 32641);

            Assert.False(relationship.Following);
        }

        [Fact]
        public async Task BlockAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldrelationship = (await tokens.Accounts.RelationshipsAsync(id => new List<long> { 32641 })).First();
            await Task.Delay(1000);

            if (oldrelationship.Blocking)
                await tokens.Accounts.UnblockAsync(id => 32641);

            await Task.Delay(1000);

            var relationship = await tokens.Accounts.BlockAsync(id => 32641);

            Assert.True(relationship.Blocking);

            await tokens.Accounts.UnblockAsync(id => 32641);
        }

        [Fact]
        public async Task UnblockAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldrelationship = (await tokens.Accounts.RelationshipsAsync(id => new List<long> { 32641 })).First();
            await Task.Delay(1000);

            if (!oldrelationship.Blocking)
                await tokens.Accounts.BlockAsync(id => 32641);

            await Task.Delay(1000);

            var relationship = await tokens.Accounts.UnblockAsync(id => 32641);

            Assert.False(relationship.Blocking);
        }

        [Fact]
        public async Task MuteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldrelationship = (await tokens.Accounts.RelationshipsAsync(id => new List<long> { 32641 })).First();

            await Task.Delay(1000);

            if (oldrelationship.Muting)
                await tokens.Accounts.UnmuteAsync(id => 32641);

            await Task.Delay(1000);

            var relationship = await tokens.Accounts.MuteAsync(id => 32641);

            Assert.True(relationship.Muting);

            await tokens.Accounts.UnmuteAsync(id => 32641);
        }

        [Fact]
        public async Task UnmuteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldrelationship = (await tokens.Accounts.RelationshipsAsync(id => new List<long> { 32641 })).First();

            await Task.Delay(1000);

            if (!oldrelationship.Muting)
                await tokens.Accounts.MuteAsync(id => 32641);

            await Task.Delay(1000);

            var relationship = await tokens.Accounts.UnmuteAsync(id => 32641);

            Assert.False(relationship.Muting);
        }

        [Fact]
        public async Task RelationshipsTest()
        {
            var tokens = AccountInformation.GetTokens();

            var relationships = await tokens.Accounts.RelationshipsAsync(id => new List<long> { 32641 });

            Assert.Equal(relationships.Count, 1);
        }

        [Fact]
        public async Task SearchTest()
        {
            var tokens = AccountInformation.GetTokens();

            var searches = await tokens.Accounts.SearchAsync(q => "きゅうりうむ");

            Assert.NotNull(searches);
            Assert.True(searches.Count > 0);
        }
        
        [Fact]
        public async Task ListsTest()
        {
            var tokens = AccountInformation.GetTokens();

            var lists = await tokens.Accounts.ListsAsync(id => 157355);

            Assert.NotNull(lists);
        }
    }
}
