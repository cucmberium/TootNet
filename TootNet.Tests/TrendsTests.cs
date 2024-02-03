using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class TrendsTests
    {
        [Fact]
        public async Task TagsAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var tags = await tokens.Trends.TagsAsync(limit => 3);

            Assert.Equal(3, tags.Count);
            foreach (var tag in tags)
            {
                Assert.NotNull(tag.Name);
            }
        }

        [Fact]
        public async Task StatusesAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var statuses = await tokens.Trends.StatusesAsync(limit => 3);

            Assert.Equal(3, statuses.Count);
            foreach (var status in statuses)
            {
                Assert.NotNull(status.Account.Acct);
                Assert.NotNull(status.Account.UserName);
                Assert.NotNull(status.Account.Url);
                Assert.NotNull(status.Content);
            }
        }

        [Fact]
        public async Task LinksAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var trendsLinks = await tokens.Trends.LinksAsync(limit => 3);

            Assert.Equal(3, trendsLinks.Count);
            foreach (var trendLink in trendsLinks)
            {
                Assert.NotNull(trendLink.History);
            }
        }
    }
}
