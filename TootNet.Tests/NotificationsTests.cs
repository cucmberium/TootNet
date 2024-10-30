using System.Collections.Generic;
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

        [Fact(Skip = "WIP")]
        public async Task ClearAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            await tokens.Notifications.ClearAsync();

            var notifications = await tokens.Notifications.GetAsync();

            Assert.Empty(notifications);
        }

        [Fact(Skip = "WIP")]
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
        public async Task UnreadCountAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var unreadCount = await tokens.Notifications.UnreadCountAsync();

            Assert.Contains("count", unreadCount);
        }

        [Fact]
        public async Task PolicyAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var policy = await tokens.Notifications.PolicyAsync();

            Assert.NotNull(policy.ForLimitedAccounts);
            Assert.NotNull(policy.ForNewAccounts);
            Assert.NotNull(policy.ForNotFollowers);
            Assert.NotNull(policy.ForNotFollowing);
            Assert.NotNull(policy.ForPrivateMentions);
        }

        [Fact]
        public async Task UpdatePolicyAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldPolicy = await tokens.Notifications.PolicyAsync();

            await Task.Delay(1000);

            var newPolicy = await tokens.Notifications.UpdatePolicyAsync(for_not_followers => "filter");
            Assert.Equal("filter", newPolicy.ForNotFollowers);

            await Task.Delay(1000);

            await tokens.Notifications.UpdatePolicyAsync(for_not_followers => oldPolicy.ForNotFollowers);
        }

        [Fact(Skip = "WIP")]
        public async Task GetRequestsAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var notificationRequests = await tokens.Notifications.GetRequestsAsync();
            if (notificationRequests.Count == 0)
                return;

            var notificationRequest = notificationRequests.First();

            Assert.NotNull(notificationRequest.Account);
            Assert.True(notificationRequest.NotificationsCount >= 1);
        }

        [Fact(Skip = "WIP")]
        public async Task IdRequestAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var notificationRequests = await tokens.Notifications.GetRequestsAsync();
            if (notificationRequests.Count == 0)
                return;

            var notificationRequest = await tokens.Notifications.IdRequestAsync(id => notificationRequests.First().Id);

            Assert.Equal(notificationRequests.First().Id, notificationRequest.Id);
        }

        [Fact(Skip = "WIP")]
        public async Task AcceptRequestAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var notificationRequests = await tokens.Notifications.GetRequestsAsync();
            if (notificationRequests.Count == 0)
                return;

            await tokens.Notifications.AcceptRequestAsync(id => notificationRequests.First().Id);
        }

        [Fact(Skip = "WIP")]
        public async Task DismissRequestAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var notificationRequests = await tokens.Notifications.GetRequestsAsync();
            if (notificationRequests.Count == 0)
                return;

            await tokens.Notifications.DismissRequestAsync(id => notificationRequests.First().Id);
        }

        [Fact(Skip = "WIP")]
        public async Task AcceptRequestsAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var notificationRequests = await tokens.Notifications.GetRequestsAsync();
            if (notificationRequests.Count == 0)
                return;

            await tokens.Notifications.AcceptRequestAsync(id => new List<long>{ notificationRequests.First().Id });
        }

        [Fact(Skip = "WIP")]
        public async Task DismissRequestsAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var notificationRequests = await tokens.Notifications.GetRequestsAsync();
            if (notificationRequests.Count == 0)
                return;

            await tokens.Notifications.DismissRequestAsync(id => new List<long> { notificationRequests.First().Id });
        }

        [Fact]
        public async Task GetMergedRequestsAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var mergedRequests = await tokens.Notifications.GetMergedRequestsAsync();

            Assert.Contains("merged", mergedRequests);
        }
    }
}
