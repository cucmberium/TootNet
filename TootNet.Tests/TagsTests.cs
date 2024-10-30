using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class TagsTest
    {
        [Fact]
        public async Task IdAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var tag = await tokens.Tags.GetAsync(tag => "mastodon");

            Assert.NotNull(tag.Name);
        }

        [Fact]
        public async Task FollowedTagsAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var tags = await tokens.Tags.FollowedTagsAsync();

            Assert.Single(tags);
            foreach (var tag in tags)
            {
                Assert.NotNull(tag.Name);
            }
        }

        [Fact]
        public async Task FollowAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldTag = await tokens.Tags.GetAsync(tag => "test");

            await Task.Delay(1000);

            if (oldTag.Following == true)
                await tokens.Tags.UnfollowAsync(tag => "test");

            await Task.Delay(1000);

            var newTag = await tokens.Tags.FollowAsync(tag => "test");

            Assert.True(newTag.Following);

            await Task.Delay(1000);

            await tokens.Tags.UnfollowAsync(tag => "test");
        }

        [Fact]
        public async Task UnfollowAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldTag = await tokens.Tags.GetAsync(tag => "test");

            await Task.Delay(1000);

            if (oldTag.Following is false or null)
                await tokens.Tags.FollowAsync(tag => "test");

            await Task.Delay(1000);

            var newTag = await tokens.Tags.UnfollowAsync(tag => "test");

            Assert.False(newTag.Following);
        }
    }
}
