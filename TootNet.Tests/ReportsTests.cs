using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class ReportsTests
    {
        [Fact]
        public async Task PostAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
        }
    }
}
