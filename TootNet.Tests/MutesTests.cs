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

            var relationship = (await tokens.Accounts.RelationshipsAsync(id => new List<long> { 13179 })).First();

            await Task.Delay(1000);

            if (!relationship.Muting)
                await tokens.Mutes.MuteAsync(id => 13179);

            await Task.Delay(1000);

            var accounts = await tokens.Mutes.GetAsync();

            Assert.NotNull(accounts);
            Assert.True(accounts.Count > 0);
            Assert.Contains(accounts, x => x.Id == 13179);

            await Task.Delay(1000);

            await tokens.Mutes.UnmuteAsync(id => 13179);
        }

        [Fact]
        public async Task MuteAccountAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldRelationship = (await tokens.Accounts.RelationshipsAsync(id => new List<long> { 13179 })).First();

            await Task.Delay(1000);

            if (oldRelationship.Muting)
                await tokens.Mutes.UnmuteAsync(id => 13179);

            await Task.Delay(1000);

            var relationship = await tokens.Mutes.MuteAsync(id => 13179);

            Assert.True(relationship.Muting);

            await tokens.Mutes.UnmuteAsync(id => 13179);
        }

        [Fact]
        public async Task UnmuteAccountAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldRelationship = (await tokens.Accounts.RelationshipsAsync(id => new List<long> { 13179 })).First();

            await Task.Delay(1000);

            if (!oldRelationship.Muting)
                await tokens.Mutes.MuteAsync(id => 13179);

            await Task.Delay(1000);

            var relationship = await tokens.Mutes.UnmuteAsync(id => 13179);

            Assert.False(relationship.Muting);
        }
    }
}
