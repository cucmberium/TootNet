using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class DirectoryTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
            
            var accounts = await tokens.Directory.GetAsync();
            
            Assert.NotEmpty(accounts);
        }
    }
}
