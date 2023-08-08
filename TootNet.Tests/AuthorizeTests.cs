using System;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class AuthorizeTests
    {
        [Fact]
        public async Task CreateAppTest()
        {
            var authorize = new Authorize();
            
            await authorize.CreateApp(AccountInformation.Instance, "TootNet", Scope.Read | Scope.Write | Scope.Follow);

            Assert.NotNull(authorize.Instance);
            Assert.NotNull(authorize.ClientId);
            Assert.NotNull(authorize.ClientSecret);
        }

        [Fact]
        public async Task AuthorizeWithCodeTest()
        {
            var authorize = new Authorize
            {
                Instance = AccountInformation.Instance,
                ClientId = AccountInformation.ClientId,
                ClientSecret = AccountInformation.ClientSecret
            };

            var authorizeUrl = authorize.GetAuthorizeUri();

            Console.WriteLine(authorizeUrl);

            var code = Console.ReadLine()?.Trim();
            var tokens = await authorize.AuthorizeWithCode(code);

            Assert.NotNull(tokens);
            Assert.NotNull(tokens.AccessToken);
        }
    }
}
