using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class ListsTests
    {
        [Fact]
        public async Task IdAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
            
            var createdlist = await tokens.Lists.CreateAsync(title => "TootNetTest");
            var list = await tokens.Lists.IdAsync(id => createdlist.Id);

            Assert.NotNull(list);
            Assert.Equal("TootNetTest", list.Title);

            await tokens.Lists.DeleteAsync(id => createdlist.Id);
        }

        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var createdlist = await tokens.Lists.CreateAsync(title => "TootNetTest");
            var lists = await tokens.Lists.GetAsync();

            Assert.NotNull(lists);
            Assert.True(lists.Count > 0);

            await tokens.Lists.DeleteAsync(id => createdlist.Id);
        }
        
        [Fact]
        public async Task DeleteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var createdlist = await tokens.Lists.CreateAsync(title => "TootNetTest");
            await tokens.Lists.DeleteAsync(id => createdlist.Id);

            var lists = await tokens.Lists.GetAsync();
            Assert.True(lists.All(x => x.Id != createdlist.Id));
        }

        [Fact]
        public async Task CreateAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var createdlist = await tokens.Lists.CreateAsync(title => "TootNetTest");
            Assert.Equal("TootNetTest", createdlist.Title);

            await tokens.Lists.DeleteAsync(id => createdlist.Id);
        }

        [Fact]
        public async Task UpdateAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var createdlist = await tokens.Lists.CreateAsync(title => "TootNetTest");
            var updatedlist = await tokens.Lists.UpdateAsync(id => createdlist.Id, title => "TootNetTest2");
            Assert.Equal("TootNetTest", createdlist.Title);
            Assert.Equal("TootNetTest2", updatedlist.Title);

            await tokens.Lists.DeleteAsync(id => updatedlist.Id);
        }

        [Fact]
        public async Task AccountsAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var createdlist = await tokens.Lists.CreateAsync(title => "TootNetTest");
            await tokens.Lists.AddAccountAsync(id => createdlist.Id, account_ids => new List<long> { 157355 });
            var listAccounts = await tokens.Lists.AccountsAsync(id => createdlist.Id);

            Assert.NotNull(listAccounts);
            Assert.True(listAccounts.Count > 0);
            Assert.Equal(157355, listAccounts[0].Id);

            await tokens.Lists.DeleteAsync(id => createdlist.Id);
        }
        
        [Fact]
        public async Task AddAccountAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
            
            var createdlist = await tokens.Lists.CreateAsync(title => "TootNetTest");
            await tokens.Lists.AddAccountAsync(id => createdlist.Id, account_ids => new List<long> { 157355 });
            var listAccounts = await tokens.Lists.AccountsAsync(id => createdlist.Id);

            Assert.NotNull(listAccounts);
            Assert.True(listAccounts.Count > 0);
            Assert.Equal(157355, listAccounts[0].Id);

            await tokens.Lists.DeleteAsync(id => createdlist.Id);
        }

        [Fact]
        public async Task DeleteAccountAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var createdlist = await tokens.Lists.CreateAsync(title => "TootNetTest");
            await tokens.Lists.AddAccountAsync(id => createdlist.Id, account_ids => new List<long> { 157355 });
            await tokens.Lists.DeleteAccountAsync(id => createdlist.Id, account_ids => new List<long> { 157355 });
            var listAccounts = await tokens.Lists.AccountsAsync(id => createdlist.Id);

            Assert.NotNull(listAccounts);
            Assert.True(listAccounts.Count == 0);

            await tokens.Lists.DeleteAsync(id => createdlist.Id);
        }
    }
}
