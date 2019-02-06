using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class NotificationsTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var notifications = await tokens.Notifications.GetAsync();
            Assert.NotNull(notifications);
        }

        [Fact]
        public async Task IdAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var notifications = await tokens.Notifications.GetAsync();
            if (notifications.Count == 0)
                return;

            var targetNotification = notifications.First();

            await Task.Delay(1000);

            var notification = await tokens.Notifications.IdAsync(id => targetNotification.Id);

            Assert.Equal(targetNotification.Id, notification.Id);
            Assert.Equal(targetNotification.Type, notification.Type);
            Assert.Equal(targetNotification.Account.Acct, notification.Account.Acct);
        }

        [Fact]
        public async Task ClearAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
        }

        [Fact]
        public async Task DismissAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var notifications = await tokens.Notifications.GetAsync();
            if (notifications.Count == 0)
                return;

            var targetNotification = notifications.First();

            await Task.Delay(1000);

            await tokens.Notifications.DismissAsync(id => targetNotification.Id);

            await Task.Delay(1000);

            var dismissedNotifications = await tokens.Notifications.GetAsync();

            Assert.DoesNotContain(dismissedNotifications, x => x.Id == targetNotification.Id);
        }

        [Fact]
        public async Task AddPushSubscriptionAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
        }

        [Fact]
        public async Task GetPushSubscriptionAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
        }

        [Fact]
        public async Task UpdatePushSubscriptionAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
        }

        [Fact]
        public async Task DeletePushSubscriptionAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
        }
    }
}
