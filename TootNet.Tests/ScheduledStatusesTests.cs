using System.Collections.Generic;
using System.IO;
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
            long statusId = 0;
            var tokens = AccountInformation.GetTokens();
            using (var fs = new FileStream(@"./Data/image.png", FileMode.Open, FileAccess.Read))
            {
                var attachment = await tokens.MediaAttachments.PostAsync(file => fs, focus => "0.0,0.0");
                var scheduledStatus = await tokens.Statuses.PostAsync(status => "test toot future", visibility => "private", scheduled_at => "2022-12-24 12:00:00", media_ids => new List<long> { attachment.Id });
                statusId = scheduledStatus.Id;
            }
            
            await Task.Delay(1000);

            var scheduledStatuses = await tokens.ScheduledStatuses.GetAsync();

            Assert.NotNull(scheduledStatuses);
            Assert.True(scheduledStatuses.Count() > 0);

            await Task.Delay(1000);

            await tokens.ScheduledStatuses.DeleteAsync(id => statusId);
        }

        [Fact]
        public async Task IdAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var scheduledStatus = await tokens.Statuses.PostAsync(status => "test toot future2", visibility => "private", scheduled_at => "2023-12-24 12:00:00");

            await Task.Delay(1000);

            var scheduledStatus2 = await tokens.ScheduledStatuses.IdAsync(id => scheduledStatus.Id);

            Assert.NotNull(scheduledStatus2);
            Assert.True(scheduledStatus2.Params.Text == "test toot future2");

            await Task.Delay(1000);

            await tokens.ScheduledStatuses.DeleteAsync(id => scheduledStatus.Id);
        }

        [Fact]
        public async Task UpdateAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var scheduledStatus = await tokens.Statuses.PostAsync(status => "test toot future3", visibility => "private", scheduled_at => "2023-12-24 12:00:00");

            await Task.Delay(1000);

            var scheduledStatus2 = await tokens.ScheduledStatuses.IdAsync(id => scheduledStatus.Id);

            await Task.Delay(1000);

            var scheduledStatus3 = await tokens.ScheduledStatuses.UpdateAsync(id => scheduledStatus.Id, scheduled_at => "2023-12-24 11:00:00");

            Assert.NotNull(scheduledStatus3);
            Assert.True(scheduledStatus2.ScheduledAt > scheduledStatus3.ScheduledAt);

            await Task.Delay(1000);

            await tokens.ScheduledStatuses.DeleteAsync(id => scheduledStatus.Id);
        }

        [Fact]
        public async Task DeleteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var scheduledStatuses = await tokens.ScheduledStatuses.GetAsync();
            foreach (var status in scheduledStatuses)
            {
                await tokens.ScheduledStatuses.DeleteAsync(id => status.Id);
            }

            var scheduledStatus = await tokens.Statuses.PostAsync(status => "test toot future4", visibility => "private", scheduled_at => "2024-12-24 12:00:00");

            await Task.Delay(1000);

            await tokens.ScheduledStatuses.DeleteAsync(id => scheduledStatus.Id);

            await Task.Delay(1000);

            var scheduledStatuses2 = await tokens.ScheduledStatuses.GetAsync();

            Assert.NotNull(scheduledStatuses2);
            Assert.True(scheduledStatuses2.Count() == 0);
        }
    }
}
