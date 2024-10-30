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

            Assert.Equal(tokens.Instance, instance.Domain);
        }

        [Fact]
        public async Task PeersAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var peers = await tokens.Instances.PeersAsync();

            Assert.NotNull(peers);
        }

        [Fact]
        public async Task ActivityAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var activity = await tokens.Instances.ActivityAsync();

            Assert.NotNull(activity);
        }

        [Fact]
        public async Task RulesAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var rules = await tokens.Instances.RulesAsync();

            Assert.NotNull(rules);
        }

        [Fact]
        public async Task DomainBlocksAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var domainBlocks = await tokens.Instances.DomainBlocksAsync();

            Assert.NotNull(domainBlocks);
        }

        [Fact]
        public async Task ExtendedDescriptionAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var extendedDescription = await tokens.Instances.ExtendedDescriptionAsync();

            Assert.NotNull(extendedDescription);
        }
    }
}
