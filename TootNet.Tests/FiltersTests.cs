using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class FiltersTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var filters = await tokens.Filters.GetAsync();

            Assert.NotEmpty(filters);
            Assert.Contains(filters, x => x.Title == "tootnet");
        }

        [Fact]
        public async Task IdAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var filter = await tokens.Filters.IdAsync(id => 50143);

            Assert.Equal("tootnet", filter.Title);
        }

        [Fact]
        public async Task PostAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var filter = await tokens.Filters.PostAsync(title => "test", context => new[]{ "home" });

            Assert.Equal("test", filter.Title);

            await Task.Delay(1000);

            await tokens.Filters.DeleteAsync(id => filter.Id);
        }

        [Fact]
        public async Task PutAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldFilter = await tokens.Filters.PostAsync(title => "test", context => new[] { "home" });

            await Task.Delay(1000);

            var newFilter = await tokens.Filters.PutAsync(id => oldFilter.Id, title => "test2");

            Assert.Equal("test2", newFilter.Title);

            await Task.Delay(1000);

            await tokens.Filters.DeleteAsync(id => newFilter.Id);
        }

        [Fact]
        public async Task DeleteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var filter = await tokens.Filters.PostAsync(title => "test", context => new[] { "home" });

            await Task.Delay(1000);

            await tokens.Filters.DeleteAsync(id => filter.Id);

            await Task.Delay(1000);

            var filters = await tokens.Filters.GetAsync();

            Assert.DoesNotContain(filters, x => x.Title == "test");
        }

        [Fact]
        public async Task GetFilterKeywordsAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var filterKeywords = await tokens.Filters.GetFilterKeywordsAsync(filter_id => 50143);

            Assert.Contains(filterKeywords, keyword => keyword.Keyword == "fugafuga");
        }

        [Fact]
        public async Task PostFilterKeywordsAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var filterKeyword = await tokens.Filters.PostFilterKeywordsAsync(filter_id => 50143, keyword => "foobar");

            await Task.Delay(1000);

            var filterKeywords = await tokens.Filters.GetFilterKeywordsAsync(filter_id => 50143);

            Assert.Contains(filterKeywords, keyword => keyword.Keyword == "foobar");

            await Task.Delay(1000);

            await tokens.Filters.DeleteKeywordAsync(id => filterKeyword.Id);
        }

        [Fact]
        public async Task GetKeywordAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var filterKeyword = await tokens.Filters.GetKeywordAsync(id => 108834);

            Assert.Equal("fugafuga", filterKeyword.Keyword);
        }

        [Fact]
        public async Task PutKeywordAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var filterKeyword = await tokens.Filters.PutKeywordAsync(id => 108834, keyword => "hogehoge");

            Assert.Equal("hogehoge", filterKeyword.Keyword);

            await tokens.Filters.PutKeywordAsync(id => 108834, keyword => "fugafuga");
        }

        [Fact]
        public async Task DeleteKeywordAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var filterKeyword = await tokens.Filters.PostFilterKeywordsAsync(filter_id => 50143, keyword => "foobar");

            await Task.Delay(1000);

            await tokens.Filters.DeleteKeywordAsync(id => filterKeyword.Id);

            await Task.Delay(1000);

            var filterKeywords = await tokens.Filters.GetFilterKeywordsAsync(filter_id => 50143);

            Assert.DoesNotContain(filterKeywords, keyword => keyword.Keyword == "foobar");
        }

        [Fact]
        public async Task GetFilterStatusesAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var filterStatuses = await tokens.Filters.GetFilterStatusesAsync(filter_id => 50143);

            Assert.NotEmpty(filterStatuses);
            Assert.Contains(filterStatuses, status => status.StatusId == 110854506623038676);
        }

        [Fact]
        public async Task PostFilterStatusesAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var filterStatus = await tokens.Filters.PostFilterStatusesAsync(filter_id => 50143, status_id => 110362824208084074);

            await Task.Delay(1000);

            var filterStatuses = await tokens.Filters.GetFilterStatusesAsync(filter_id => 50143);

            await Task.Delay(1000);

            Assert.NotEmpty(filterStatuses);
            Assert.Contains(filterStatuses, status => status.StatusId == 110362824208084074);

            await tokens.Filters.DeleteFilterStatusAsync(id => filterStatus.Id);
        }

        [Fact]
        public async Task GetFilterStatusAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var filterStatus = await tokens.Filters.GetFilterStatusAsync(id => 12689);

            Assert.Equal(110854506623038676, filterStatus.StatusId);
        }

        [Fact]
        public async Task DeleteFilterStatusesAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var filterStatus = await tokens.Filters.PostFilterStatusesAsync(filter_id => 50143, status_id => 110362824208084074);

            await Task.Delay(1000);

            await tokens.Filters.DeleteFilterStatusAsync(id => filterStatus.Id);

            await Task.Delay(1000);

            var filterStatuses = await tokens.Filters.GetFilterStatusesAsync(filter_id => 50143);

            Assert.DoesNotContain(filterStatuses, status => status.StatusId == 110362824208084074);
        }
    }
}
