using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class SearchTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var search = await tokens.Search.GetAsync(q => "きゅうりうむ");

            Assert.NotNull(search);
            Assert.NotNull(search.Statuses);
            Assert.NotNull(search.Accounts);
            Assert.NotNull(search.Hashtags);
        }
    }
}
