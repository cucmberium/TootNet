using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class EndorsementsTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            await tokens.Endorsements.PinAsync(id => 157355);

            await Task.Delay(1000);

            var endorsements = await tokens.Endorsements.GetAsync();

            Assert.True(endorsements.Count() > 0);
            Assert.Contains(endorsements, x => x.Acct == "cucmberium@mstdn.maud.io");

            await Task.Delay(1000);

            await tokens.Endorsements.UnpinAsync(id => 157355);
        }

        [Fact]
        public async Task PinAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            await tokens.Endorsements.PinAsync(id => 157355);

            await Task.Delay(1000);

            var endorsements = await tokens.Endorsements.GetAsync();

            Assert.True(endorsements.Count() > 0);
            Assert.Contains(endorsements, x => x.Acct == "cucmberium@mstdn.maud.io");

            await Task.Delay(1000);

            await tokens.Endorsements.UnpinAsync(id => 157355);
        }

        [Fact]
        public async Task UnpinAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            await tokens.Endorsements.PinAsync(id => 157355);

            await Task.Delay(1000);

            await tokens.Endorsements.UnpinAsync(id => 157355);

            await Task.Delay(1000);

            var endorsements = await tokens.Endorsements.GetAsync();

            Assert.DoesNotContain(endorsements, x => x.Acct == "cucmberium@mstdn.maud.io");
        }
    }
}
