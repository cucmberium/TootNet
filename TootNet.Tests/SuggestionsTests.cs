using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class SuggestionsTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            var accounts = await tokens.Suggestions.GetAsync();

            Assert.NotEmpty(accounts);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var tokens = AccountInformation.GetTokens();

            var accounts = await tokens.Suggestions.GetAsync();

            await Task.Delay(1000);

            var targetAccountId = accounts.First().Account.Id;
            await tokens.Suggestions.DeleteAsync(account_id => targetAccountId);

            await Task.Delay(1000);

            var removedAccounts = await tokens.Suggestions.GetAsync();
            Assert.Empty(removedAccounts.Where(x => x.Account.Id == targetAccountId));
        }
    }
}
