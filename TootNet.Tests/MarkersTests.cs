using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class MarkersTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var marker = await tokens.Markers.GetAsync(timeline => new List<string> {"home"});

            Assert.NotNull(marker);
        }

        [Fact]
        public async Task PostAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var homes = await tokens.Timelines.HomeAsync();

            var marker = await tokens.Markers.PostAsync(new Dictionary<string, object> {{"home[last_read_id]", homes.First().Id }});

            Assert.NotNull(marker);
        }
    }
}
