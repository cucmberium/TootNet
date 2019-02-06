using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class CustomEmojiTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
            
            var emojis = await tokens.CustomEmoji.GetAsync();
            
            Assert.NotNull(emojis);
            Assert.True(emojis.Any());
            Assert.Contains(emojis, x => x.Shortcode == "amazon");
        }
    }
}
