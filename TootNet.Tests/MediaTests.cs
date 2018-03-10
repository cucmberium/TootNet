using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class MediaTests
    {
        [Fact]
        public async Task PostAsyncTest()
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

        [Fact]
        public async Task UpdateAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            using (var fs = new FileStream(@"./Data/image.png", FileMode.Open, FileAccess.Read))
            {
                var attachment = await tokens.Media.PostAsync(file => fs, focus => "0.0,0.0");
                var updatedAttachment = await tokens.Media.UpdateAsync(id => attachment.Id, description => "flanchan");

                Assert.NotNull(updatedAttachment);
                Assert.NotNull(updatedAttachment.PreviewUrl);
                Assert.NotNull(updatedAttachment.Url);
                Assert.Equal("flanchan", updatedAttachment.Description);
            }
        }
    }
}
