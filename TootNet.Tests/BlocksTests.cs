using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class BlocksTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
            
            var relationship = (await tokens.Accounts.RelationshipsAsync(id => new List<long> { 32641 })).First();

            await Task.Delay(1000);

            if (!relationship.Blocking)
                await tokens.Blocks.BlockAsync(id => 32641);

            await Task.Delay(1000);

            var accounts = await tokens.Blocks.GetAsync();

            Assert.NotNull(accounts);
            Assert.True(accounts.Count > 0);
            Assert.Contains(accounts, x => x.Id == 32641);

            await Task.Delay(1000);

            await tokens.Blocks.UnblockAsync(id => 32641);
        }

        [Fact]
        public async Task BlockAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldRelationship = (await tokens.Accounts.RelationshipsAsync(id => new List<long> { 32641 })).First();
            await Task.Delay(1000);

            if (oldRelationship.Blocking)
                await tokens.Blocks.UnblockAsync(id => 32641);

            await Task.Delay(1000);

            var relationship = await tokens.Blocks.BlockAsync(id => 32641);

            Assert.True(relationship.Blocking);

            await tokens.Blocks.UnblockAsync(id => 32641);
        }

        [Fact]
        public async Task UnblockAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldRelationship = (await tokens.Accounts.RelationshipsAsync(id => new List<long> { 32641 })).First();
            await Task.Delay(1000);

            if (!oldRelationship.Blocking)
                await tokens.Blocks.BlockAsync(id => 32641);

            await Task.Delay(1000);

            var relationship = await tokens.Blocks.UnblockAsync(id => 32641);

            Assert.False(relationship.Blocking);
        }
    }
}
