using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class PreferencesTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var preferences = await tokens.Preferences.GetAsync();

            Assert.NotNull(preferences);
        }
    }
}
