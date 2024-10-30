using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class GroupedNotificationsTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var notifications = await tokens.GroupedNotifications.GetAsync();
            Assert.NotNull(notifications);
        }

        [Fact(Skip = "WIP")]
        public async Task GroupKeyAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var notifications = await tokens.GroupedNotifications.GetAsync();
            if (!notifications.NotificationGroups.Any())
                return;

            var targetNotification = notifications.NotificationGroups.First();

            await Task.Delay(1000);

            var notification = await tokens.GroupedNotifications.GroupKeyAsync(group_key => targetNotification.GroupKey);

            Assert.NotNull(notification.NotificationGroups);
        }

        [Fact(Skip = "WIP")]
        public async Task DismissAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var notifications = await tokens.GroupedNotifications.GetAsync();
            if (!notifications.NotificationGroups.Any())
                return;

            var targetNotification = notifications.NotificationGroups.First();

            await Task.Delay(1000);

            await tokens.GroupedNotifications.DismissAsync(group_key => targetNotification.GroupKey);
        }

        [Fact(Skip = "WIP")]
        public async Task AccountsAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var notifications = await tokens.GroupedNotifications.GetAsync();
            if (!notifications.NotificationGroups.Any())
                return;

            var targetNotification = notifications.NotificationGroups.First();

            var accounts = await tokens.GroupedNotifications.AccountsAsync(group_key => targetNotification.GroupKey);

            Assert.NotEmpty(accounts);
        }

        [Fact]
        public async Task UnreadCountAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var unreadCount = await tokens.GroupedNotifications.UnreadCountAsync();

            Assert.Contains("count", unreadCount);
        }
    }
}
