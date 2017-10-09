using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class MediaTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            using (var fs = new FileStream(@"./Data/image.png", FileMode.Open, FileAccess.Read))
            {
                var attachment = await tokens.Media.PostAsync(file => fs);

                Assert.NotNull(attachment);
                Assert.NotNull(attachment.PreviewUrl);
                Assert.NotNull(attachment.Url);
            }
        }
    }
}
