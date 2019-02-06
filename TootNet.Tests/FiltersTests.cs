using System.Collections.Generic;
using System.Linq;
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

            var filter = await tokens.Filters.PostAsync(phrase => "test", context => new List<string> {"home"});

            await Task.Delay(1000);

            var filters = await tokens.Filters.GetAsync();

            Assert.NotNull(filters);
            Assert.True(filters.Any());
            Assert.Contains(filters, x => x.Id == filter.Id);
            Assert.Contains(filters, x => x.Phrase == "test");

            await Task.Delay(1000);

            await tokens.Filters.DeleteAsync(id => filter.Id);
        }

        [Fact]
        public async Task PostAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var filter = await tokens.Filters.PostAsync(phrase => "test2", context => new List<string> { "home" });

            await Task.Delay(1000);

            var filters = await tokens.Filters.GetAsync();

            Assert.NotNull(filters);
            Assert.True(filters.Any());
            Assert.Contains(filters, x => x.Id == filter.Id);
            Assert.Contains(filters, x => x.Phrase == "test2");

            await Task.Delay(1000);

            await tokens.Filters.DeleteAsync(id => filter.Id);
        }
        [Fact]
        public async Task IdAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var filter = await tokens.Filters.PostAsync(phrase => "test6", context => new List<string> { "home" });

            await Task.Delay(1000);

            var filter2 = await tokens.Filters.IdAsync(id => filter.Id);

            Assert.NotNull(filter2);
            Assert.True(filter.Id == filter2.Id);
            Assert.True(filter.Phrase == filter2.Phrase);

            await Task.Delay(1000);

            await tokens.Filters.DeleteAsync(id => filter.Id);
        }

        [Fact]
        public async Task UpdateAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var filter = await tokens.Filters.PostAsync(phrase => "test3", context => new List<string> { "home" });

            await Task.Delay(1000);
            
            var updatedFilter = await tokens.Filters.UpdateAsync(id => filter.Id, phrase => "test4", context => new List<string> { "home" });

            var filters = await tokens.Filters.GetAsync();

            Assert.NotNull(filters);
            Assert.True(filters.Any());
            Assert.Contains(filters, x => x.Id == filter.Id);
            Assert.Contains(filters, x => x.Phrase == "test4");

            await Task.Delay(1000);

            await tokens.Filters.DeleteAsync(id => filter.Id);
        }

        [Fact]
        public async Task DeleteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var filter = await tokens.Filters.PostAsync(phrase => "test5", context => new List<string> { "home" });

            await Task.Delay(1000);

            await tokens.Filters.DeleteAsync(id => filter.Id);

            await Task.Delay(1000);

            var filters = await tokens.Filters.GetAsync();

            Assert.NotNull(filters);
            Assert.DoesNotContain(filters, x => x.Id == filter.Id);
        }
    }
}
