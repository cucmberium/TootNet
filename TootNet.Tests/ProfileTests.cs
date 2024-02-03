using System.Linq;
using System.Threading.Tasks;
using TootNet.Objects;
using Xunit;

namespace TootNet.Tests
{
    public class ProfileTests
    {
        [Fact]
        public async Task DeleteAvatarAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var account = await tokens.Profile.DeleteAvatarAsync();

            Assert.NotNull(account);
        }

        [Fact]
        public async Task DeleteHeaderAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var account = await tokens.Profile.DeleteHeaderAsync();

            Assert.NotNull(account);
        }
    }
}
