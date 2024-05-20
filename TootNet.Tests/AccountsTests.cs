using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class AccountsTests
    {
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

            var oldAccount = await tokens.Accounts.VerifyCredentialsAsync();

            await Task.Delay(1000);

            var newAccount = await tokens.Accounts.UpdateCredentialsAsync(display_name => "test");

            Assert.NotNull(newAccount.Acct);
            Assert.NotNull(newAccount.UserName);
            Assert.NotNull(newAccount.Url);
            Assert.Equal("test", newAccount.DisplayName);

            await Task.Delay(1000);

            await tokens.Accounts.UpdateCredentialsAsync(display_name => oldAccount.DisplayName);
        }

        [Fact]
        public async Task IdAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var account = await tokens.Accounts.IdAsync(id => 13179);

            Assert.NotNull(account.Acct);
            Assert.NotNull(account.UserName);
            Assert.NotNull(account.Url);
        }

        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var accounts = await tokens.Accounts.GetAsync(id => new List<long> { 13179 });

            Assert.NotEmpty(accounts);
            var account = accounts.First();
            Assert.NotNull(account.Acct);
            Assert.NotNull(account.UserName);
            Assert.NotNull(account.Url);
        }

        [Fact]
        public async Task StatusesAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var statuses = await tokens.Accounts.StatusesAsync(id => 13179, limit => 5);

            Assert.Equal(5, statuses.Count);
            foreach (var status in statuses)
            {
                Assert.NotNull(status.Account.Acct);
                Assert.NotNull(status.Account.UserName);
                Assert.NotNull(status.Account.Url);
                Assert.NotNull(status.Content);
            }
        }

        [Fact]
        public async Task FollowersAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var accounts = await tokens.Accounts.FollowersAsync(id => 13179, limit => 5);

            Assert.Equal(5, accounts.Count);
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

            var accounts = await tokens.Accounts.FollowingAsync(id => 13179, limit => 2);

            Assert.Equal(2, accounts.Count);
            foreach (var account in accounts)
            {
                Assert.NotNull(account.Acct);
                Assert.NotNull(account.UserName);
                Assert.NotNull(account.Url);
            }
        }

        [Fact]
        public async Task FeaturedTagsAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var featuredTags = await tokens.Accounts.FeaturedTagsAsync(id => 111154122340688370);

            foreach (var tag in featuredTags)
            {
                Assert.NotNull(tag.Name);
            }
        }

        [Fact]
        public async Task FollowAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldrelationship = (await tokens.Accounts.RelationshipsAsync(id => new List<long> { 13179 })).First();

            await Task.Delay(1000);

            if (oldrelationship.Following)
                await tokens.Accounts.UnfollowAsync(id => 13179);

            await Task.Delay(1000);

            var relationship = await tokens.Accounts.FollowAsync(id => 13179);

            Assert.True(relationship.Following);
        }

        [Fact]
        public async Task UnfollowAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldrelationship = (await tokens.Accounts.RelationshipsAsync(id => new List<long> { 13179 })).First();

            await Task.Delay(1000);

            if (!oldrelationship.Following)
                await tokens.Accounts.FollowAsync(id => 13179);

            await Task.Delay(1000);

            var relationship = await tokens.Accounts.UnfollowAsync(id => 13179);

            Assert.False(relationship.Following);
        }

        [Fact]
        public async Task RemoveFromFollowersAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var relationship = await tokens.Accounts.RemoveFromFollowersAsync(id => 13179);

            Assert.False(relationship.FollowedBy);
        }

        [Fact]
        public async Task NoteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var relationship = await tokens.Accounts.NoteAsync(id => 13179, comment => "hoge");

            Assert.Equal("hoge", relationship.Note);
        }

        [Fact]
        public async Task RelationshipsAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var relationships = await tokens.Accounts.RelationshipsAsync(id => new List<long> { 13179 });

            Assert.Single(relationships);
        }

        [Fact]
        public async Task FamiliarFollowersAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var familiarFollowers = await tokens.Accounts.FamiliarFollowersAsync(id => new List<long> { 13179 });

            foreach (var familiarFollower in familiarFollowers)
            {
                Assert.NotNull(familiarFollower.Accounts);
            }
        }

        [Fact]
        public async Task SearchAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var searches = await tokens.Accounts.SearchAsync(q => "Mastodon");

            Assert.NotEmpty(searches);
        }

        [Fact]
        public async Task LookupAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var account = await tokens.Accounts.LookupAsync(acct => "cucmberium@mstdn.maud.io");

            Assert.NotNull(account.Acct);
            Assert.NotNull(account.UserName);
            Assert.NotNull(account.Url);
        }
    }
}
