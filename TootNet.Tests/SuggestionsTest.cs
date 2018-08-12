using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class SuggestionsTest
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
            
            var accounts = await tokens.Suggestions.GetAsync();

            Assert.NotNull(accounts);
            Assert.True(accounts.Count() > 0);
        }
    }
}
