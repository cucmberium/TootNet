using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class AnnouncementsTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var announcements = await tokens.Announcements.GetAsync(with_dismissed => true);

            foreach (var announcement in announcements)
            {
                Assert.NotNull(announcement.Content);
            }
        }

        [Fact]
        public async Task DismissAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldAnnouncement = (await tokens.Announcements.GetAsync(with_dismissed => true)).First();

            await Task.Delay(1000);

            await tokens.Announcements.DismissAsync(id => oldAnnouncement.Id);

            await Task.Delay(1000);

            var newAnnouncement = (await tokens.Announcements.GetAsync(with_dismissed => true)).First(announcement => announcement.Id == oldAnnouncement.Id);

            Assert.True(newAnnouncement.Read);
        }

        [Fact]
        public async Task PutReactionAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var announcement = (await tokens.Announcements.GetAsync(with_dismissed => true)).First();

            await Task.Delay(1000);

            await tokens.Announcements.PutReactionAsync(id => announcement.Id, name => "mastodon");
        }

        [Fact]
        public async Task DeleteReactionAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var announcement = (await tokens.Announcements.GetAsync(with_dismissed => true)).First();

            await Task.Delay(1000);

            await tokens.Announcements.DeleteReactionAsync(id => announcement.Id, name => "mastodon");
        }
    }
}
