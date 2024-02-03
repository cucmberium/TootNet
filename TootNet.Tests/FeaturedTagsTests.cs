using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class FeaturedTagsTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
            
            var featuredTags = await tokens.FeaturedTags.GetAsync();

            Assert.NotEmpty(featuredTags);
            Assert.Contains(featuredTags, x => x.Name == "tootnet");
        }

        [Fact]
        public async Task PostAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var featuredTag = await tokens.FeaturedTags.PostAsync(name => "test");

            await Task.Delay(1000);

            var featuredTags = await tokens.FeaturedTags.GetAsync();

            Assert.NotEmpty(featuredTags);
            Assert.Contains(featuredTags, x => x.Name == "test");

            await Task.Delay(1000);

            await tokens.FeaturedTags.DeleteAsync(id => featuredTag.Id);
        }

        [Fact]
        public async Task DeleteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var featuredTag = await tokens.FeaturedTags.PostAsync(name => "test");

            await Task.Delay(1000);

            await tokens.FeaturedTags.DeleteAsync(id => featuredTag.Id);

            await Task.Delay(1000);

            var featuredTags = await tokens.FeaturedTags.GetAsync();

            Assert.DoesNotContain(featuredTags, x => x.Name == "test");
        }

        [Fact]
        public async Task SuggestionsAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var featuredTags = await tokens.FeaturedTags.SuggestionsAsync();

            Assert.NotEmpty(featuredTags);
        }
    }
}
