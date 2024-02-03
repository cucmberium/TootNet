using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class ListsTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var createdlist = await tokens.Lists.PostAsync(title => "TootNetTest");

            await Task.Delay(1000);

            var lists = await tokens.Lists.GetAsync();

            Assert.NotNull(lists);
            Assert.True(lists.Count > 0);

            await Task.Delay(1000);

            await tokens.Lists.DeleteAsync(id => createdlist.Id);
        }

        [Fact]
        public async Task IdAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var createdlist = await tokens.Lists.PostAsync(title => "TootNetTest");

            await Task.Delay(1000);

            var list = await tokens.Lists.IdAsync(id => createdlist.Id);

            Assert.NotNull(list);
            Assert.Equal("TootNetTest", list.Title);

            await Task.Delay(1000);

            await tokens.Lists.DeleteAsync(id => createdlist.Id);
        }

        [Fact]
        public async Task PostAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var createdlist = await tokens.Lists.PostAsync(title => "TootNetTest");

            Assert.Equal("TootNetTest", createdlist.Title);

            await Task.Delay(1000);

            await tokens.Lists.DeleteAsync(id => createdlist.Id);
        }

        [Fact]
        public async Task PutAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var createdlist = await tokens.Lists.PostAsync(title => "TootNetTest");

            await Task.Delay(1000);

            var updatedlist = await tokens.Lists.PutAsync(id => createdlist.Id, title => "TootNetTest2");

            Assert.Equal("TootNetTest", createdlist.Title);
            Assert.Equal("TootNetTest2", updatedlist.Title);

            await Task.Delay(1000);

            await tokens.Lists.DeleteAsync(id => updatedlist.Id);
        }

        [Fact]
        public async Task DeleteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var createdlist = await tokens.Lists.PostAsync(title => "TootNetTest");

            await Task.Delay(1000);

            await tokens.Lists.DeleteAsync(id => createdlist.Id);

            await Task.Delay(1000);

            var lists = await tokens.Lists.GetAsync();

            Assert.True(lists.All(x => x.Id != createdlist.Id));
        }
        
        [Fact(Skip = "WIP")]
        public async Task GetAccountsAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var createdlist = await tokens.Lists.PostAsync(title => "TootNetTest");

            await Task.Delay(1000);

            await tokens.Lists.PostAccountsAsync(id => createdlist.Id, account_ids => new List<long> { 13179 });

            await Task.Delay(1000);

            var listAccounts = await tokens.Lists.GetAccountsAsync(id => createdlist.Id);

            Assert.NotNull(listAccounts);
            Assert.True(listAccounts.Count > 0);
            Assert.Equal(13179, listAccounts[0].Id);

            await Task.Delay(1000);

            await tokens.Lists.DeleteAsync(id => createdlist.Id);
        }

        [Fact(Skip = "WIP")]
        public async Task AddAccountAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
            
            var createdlist = await tokens.Lists.PostAsync(title => "TootNetTest");

            await Task.Delay(1000);

            await tokens.Lists.PostAccountsAsync(id => createdlist.Id, account_ids => new List<long> { 13179 });

            await Task.Delay(1000);

            var listAccounts = await tokens.Lists.GetAccountsAsync(id => createdlist.Id);

            Assert.NotNull(listAccounts);
            Assert.True(listAccounts.Count > 0);
            Assert.Equal(13179, listAccounts[0].Id);

            await Task.Delay(1000);

            await tokens.Lists.DeleteAsync(id => createdlist.Id);
        }

        [Fact(Skip = "WIP")]
        public async Task DeleteAccountAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var createdlist = await tokens.Lists.PostAsync(title => "TootNetTest");

            await Task.Delay(1000);

            await tokens.Lists.PostAccountsAsync(id => createdlist.Id, account_ids => new List<long> { 13179 });

            await Task.Delay(1000);

            await tokens.Lists.DeleteAccountsAsync(id => createdlist.Id, account_ids => new List<long> { 13179 });

            await Task.Delay(1000);

            var listAccounts = await tokens.Lists.GetAccountsAsync(id => createdlist.Id);

            Assert.NotNull(listAccounts);
            Assert.True(listAccounts.Count == 0);

            await Task.Delay(1000);

            await tokens.Lists.DeleteAsync(id => createdlist.Id);
        }

        [Fact(Skip = "WIP")]
        public async Task GetAccountsListsAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var createdlist = await tokens.Lists.PostAsync(title => "TootNetTest");

            await Task.Delay(1000);

            await tokens.Lists.PostAccountsAsync(id => createdlist.Id, account_ids => new List<long> { 13179 });

            await Task.Delay(1000);

            var listAccounts = await tokens.Lists.GetAccountsListsAsync(id => 13179);

            Assert.NotNull(listAccounts);
            Assert.True(listAccounts.Count > 0);

            await Task.Delay(1000);

            await tokens.Lists.DeleteAsync(id => createdlist.Id);
        }
    }
}
