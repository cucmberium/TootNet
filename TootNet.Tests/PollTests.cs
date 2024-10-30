using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class PollTests
    {
        [Fact]
        public async Task IdAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var poll = await tokens.Polls.IdAsync(id => 659057);

            Assert.NotNull(poll);
        }

        [Fact(Skip = "WIP")]
        public async Task VoteAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var poll = await tokens.Polls.VotesAsync(id => 659057, choices => new List<int> { 0 });

            Assert.NotNull(poll);
        }
    }
}
