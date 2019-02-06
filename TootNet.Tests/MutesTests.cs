using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class MutesTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var relationship = (await tokens.Accounts.RelationshipsAsync(id => new List<long> { 32641 })).First();

            await Task.Delay(1000);

            if (!relationship.Muting)
                await tokens.Mutes.MuteAccountAsync(id => 32641);

            await Task.Delay(1000);

            var accounts = await tokens.Mutes.GetAsync();

            Assert.NotNull(accounts);
            Assert.True(accounts.Count > 0);
            Assert.Contains(accounts, x => x.Id == 32641);

            await Task.Delay(1000);

            await tokens.Mutes.UnmuteAccountAsync(id => 32641);
        }

        [Fact]
        public async Task MuteAccountAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldRelationship = (await tokens.Accounts.RelationshipsAsync(id => new List<long> { 32641 })).First();

            await Task.Delay(1000);

            if (oldRelationship.Muting)
                await tokens.Mutes.UnmuteAccountAsync(id => 32641);

            await Task.Delay(1000);

            var relationship = await tokens.Mutes.MuteAccountAsync(id => 32641);

            Assert.True(relationship.Muting);

            await tokens.Mutes.UnmuteAccountAsync(id => 32641);
        }

        [Fact]
        public async Task UnmuteAccountAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldRelationship = (await tokens.Accounts.RelationshipsAsync(id => new List<long> { 32641 })).First();

            await Task.Delay(1000);

            if (!oldRelationship.Muting)
                await tokens.Mutes.MuteAccountAsync(id => 32641);

            await Task.Delay(1000);

            var relationship = await tokens.Mutes.UnmuteAccountAsync(id => 32641);

            Assert.False(relationship.Muting);
        }

        [Fact]
        public async Task MuteStatusAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var status = await tokens.Statuses.IdAsync(id => 45720257);

            await Task.Delay(1000);

            if (status.Muted == true)
                await tokens.Mutes.UnmuteStatusAsync(id => 45720257);

            await Task.Delay(1000);

            var mutedStatus = await tokens.Mutes.MuteStatusAsync(id => 45720257);

            Assert.True(mutedStatus.Muted);

            await Task.Delay(1000);

            await tokens.Mutes.UnmuteStatusAsync(id => 45720257);
        }

        [Fact]
        public async Task UnmuteStatusAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var status = await tokens.Statuses.IdAsync(id => 45720257);

            await Task.Delay(1000);

            if (status.Muted == false || status.Muted == null)
                await tokens.Mutes.MuteStatusAsync(id => 45720257);

            await Task.Delay(1000);

            var mutedStatus = await tokens.Mutes.UnmuteStatusAsync(id => 45720257);

            Assert.False(mutedStatus.Muted);
        }
    }
}
