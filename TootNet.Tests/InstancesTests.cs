using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class InstancesTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var instance = await tokens.Instances.GetAsync();

            Assert.Equal(instance.Uri, tokens.Instance);
        }
    }
}
