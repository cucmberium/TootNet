using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class DomainBlocks
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            await tokens.DomainBlocks.PostAsync(domain => "pawoo.net");

            await Task.Delay(1000);

            var domainblocks = await tokens.DomainBlocks.GetAsync();

            Assert.True(domainblocks.Count > 0);
            Assert.Contains("pawoo.net", domainblocks);

            await Task.Delay(1000);

            await tokens.DomainBlocks.DeleteAsync(domain => "pawoo.net");
        }

        [Fact]
        public async Task PostAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            await tokens.DomainBlocks.PostAsync(domain => "pawoo.net");

            await Task.Delay(1000);

            var domainblocks = await tokens.DomainBlocks.GetAsync();

            Assert.True(domainblocks.Count > 0);
            Assert.Contains("pawoo.net", domainblocks);

            await Task.Delay(1000);

            await tokens.DomainBlocks.DeleteAsync(domain => "pawoo.net");
        }

        [Fact]
        public async Task DeleteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
            
            await tokens.DomainBlocks.PostAsync(domain => "pawoo.net");

            await Task.Delay(1000);

            await tokens.DomainBlocks.DeleteAsync(domain => "pawoo.net");

            await Task.Delay(1000);

            var domainblocks = await tokens.DomainBlocks.GetAsync();

            Assert.DoesNotContain("pawoo.net", domainblocks);
        }
    }
}
