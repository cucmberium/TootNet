using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class CustomEmojisTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
            
            var emojis = await tokens.CustomEmojis.GetAsync();
            
            Assert.NotEmpty(emojis);
            Assert.Contains(emojis, x => x.Shortcode == "mastodon");
        }
    }
}
