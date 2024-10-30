using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class OEmbedTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var oembed = await tokens.OEmbed.GetAsync(url => "https://mastodon.social/@tootnet/111155004820251442");

            Assert.NotNull(oembed);
        }
    }
}
