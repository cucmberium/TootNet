using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class ScheduledStatusesTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var scheduledStatus = await tokens.Statuses.PostAsync(status => "test toot future", visibility => "private", scheduled_at => "2022-12-24 12:00:00");
            
            await Task.Delay(1000);

            var scheduledStatuses = await tokens.ScheduledStatuses.GetAsync();

            Assert.NotNull(scheduledStatuses);
            Assert.True(scheduledStatuses.Count() > 0);

            await Task.Delay(1000);

            await tokens.ScheduledStatuses.DeleteAsync(id => scheduledStatus.Id);
        }

        [Fact]
        public async Task IdAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var scheduledStatus = await tokens.Statuses.PostAsync(status => "test toot future2", visibility => "private", scheduled_at => "2023-12-24 12:00:00");

            await Task.Delay(1000);

            var scheduledStatus2 = await tokens.ScheduledStatuses.IdAsync();

            Assert.NotNull(scheduledStatus2);
            Assert.True(scheduledStatus2.Params.Count() > 0);

            await Task.Delay(1000);

            await tokens.ScheduledStatuses.DeleteAsync(id => scheduledStatus.Id);
        }

        [Fact]
        public async Task UpdateAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var scheduledStatus = await tokens.Statuses.PostAsync(status => "test toot future3", visibility => "private", scheduled_at => "2023-12-24 12:00:00");

            await Task.Delay(1000);

            var scheduledStatus2 = await tokens.ScheduledStatuses.IdAsync();

            await Task.Delay(1000);

            var scheduledStatus3 = await tokens.ScheduledStatuses.UpdateAsync(id => scheduledStatus.Id, scheduled_at => "2023-12-24 11:00:00");

            Assert.NotNull(scheduledStatus3);
            Assert.True(scheduledStatus2.ScheduledAt < scheduledStatus3.ScheduledAt);

            await Task.Delay(1000);

            await tokens.ScheduledStatuses.DeleteAsync(id => scheduledStatus.Id);
        }

        [Fact]
        public async Task DeleteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var scheduledStatus = await tokens.Statuses.PostAsync(status => "test toot future4", visibility => "private", scheduled_at => "2024-12-24 12:00:00");

            await Task.Delay(1000);

            await tokens.ScheduledStatuses.DeleteAsync(id => scheduledStatus.Id);

            await Task.Delay(1000);

            var scheduledStatuses = await tokens.ScheduledStatuses.GetAsync();

            Assert.NotNull(scheduledStatuses);
            Assert.True(scheduledStatuses.Count() == 0);
        }
    }
}
