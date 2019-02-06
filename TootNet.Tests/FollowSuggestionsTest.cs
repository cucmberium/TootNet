using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class FollowSuggestionsTest
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
            
            var accounts = await tokens.FollowSuggestions.GetAsync();

            Assert.NotNull(accounts);
            Assert.True(accounts.Count() > 0);
        }

        [Fact]
        public async Task DeleteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
        }
    }
}
