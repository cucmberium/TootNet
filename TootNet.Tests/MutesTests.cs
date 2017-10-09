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
                await tokens.Accounts.MuteAsync(id => 32641);

            await Task.Delay(1000);

            var accounts = await tokens.Mutes.GetAsync();

            Assert.NotNull(accounts);
            Assert.True(accounts.Count > 0);
            Assert.True(accounts.Any(x => x.Id == 32641));

            await Task.Delay(1000);

            await tokens.Accounts.UnmuteAsync(id => 32641);
        }
    }
}
