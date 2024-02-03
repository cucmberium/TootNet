using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class DomainBlocksTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            await tokens.DomainBlocks.PostAsync(domain => "mstdn.jp");

            await Task.Delay(1000);

            var domainBlocks = await tokens.DomainBlocks.GetAsync();

            Assert.True(domainBlocks.Count > 0);
            Assert.Contains("mstdn.jp", domainBlocks);

            await Task.Delay(1000);

            await tokens.DomainBlocks.DeleteAsync(domain => "mstdn.jp");
        }

        [Fact]
        public async Task PostAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            await tokens.DomainBlocks.PostAsync(domain => "mstdn.jp");

            await Task.Delay(1000);

            var domainBlocks = await tokens.DomainBlocks.GetAsync();

            Assert.True(domainBlocks.Count > 0);
            Assert.Contains("mstdn.jp", domainBlocks);

            await Task.Delay(1000);

            await tokens.DomainBlocks.DeleteAsync(domain => "mstdn.jp");
        }

        [Fact]
        public async Task DeleteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
            
            await tokens.DomainBlocks.PostAsync(domain => "mstdn.jp");

            await Task.Delay(1000);

            await tokens.DomainBlocks.DeleteAsync(domain => "mstdn.jp");

            await Task.Delay(1000);

            var domainBlocks = await tokens.DomainBlocks.GetAsync();

            Assert.DoesNotContain("mstdn.jp", domainBlocks);
        }
    }
}
