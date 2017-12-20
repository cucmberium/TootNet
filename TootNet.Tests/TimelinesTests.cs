using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class TimelinesTests
    {
        [Fact]
        public async Task HomeAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var statuses = await tokens.Timelines.HomeAsync(limit => 10);

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
        public async Task PublicAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var statuses = await tokens.Timelines.PublicAsync(limit => 10);

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
        public async Task TagAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var statuses = await tokens.Timelines.TagAsync(hashtag => "pixiv", limit => 10);

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
        public async Task ListAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var statuses = await tokens.Timelines.ListAsync(list_id => 208, limit => 10);

            Assert.Equal(statuses.Count, 10);
            foreach (var status in statuses)
            {
                Assert.NotNull(status.Account.Acct);
                Assert.NotNull(status.Account.UserName);
                Assert.NotNull(status.Account.Url);
                Assert.NotNull(status.Content);
            }
        }
    }
}
