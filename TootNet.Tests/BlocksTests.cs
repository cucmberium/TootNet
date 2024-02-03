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
            
            var relationship = (await tokens.Accounts.RelationshipsAsync(id => new List<long> { 13179 })).First();

            await Task.Delay(1000);

            if (!relationship.Blocking)
                await tokens.Blocks.BlockAsync(id => 13179);

            await Task.Delay(1000);

            var accounts = await tokens.Blocks.GetAsync();

            Assert.NotEmpty(accounts);
            Assert.Contains(accounts, x => x.Id == 13179);

            await Task.Delay(1000);

            await tokens.Blocks.UnblockAsync(id => 13179);
        }

        [Fact]
        public async Task BlockAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldRelationship = (await tokens.Accounts.RelationshipsAsync(id => new List<long> { 13179 })).First();

            await Task.Delay(1000);

            if (oldRelationship.Blocking)
                await tokens.Blocks.UnblockAsync(id => 13179);

            await Task.Delay(1000);

            var relationship = await tokens.Blocks.BlockAsync(id => 13179);

            Assert.True(relationship.Blocking);

            await tokens.Blocks.UnblockAsync(id => 13179);
        }

        [Fact]
        public async Task UnblockAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oldRelationship = (await tokens.Accounts.RelationshipsAsync(id => new List<long> { 13179 })).First();

            await Task.Delay(1000);

            if (!oldRelationship.Blocking)
                await tokens.Blocks.BlockAsync(id => 13179);

            await Task.Delay(1000);

            var relationship = await tokens.Blocks.UnblockAsync(id => 13179);

            Assert.False(relationship.Blocking);
        }
    }
}
