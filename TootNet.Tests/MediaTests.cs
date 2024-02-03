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
        public async Task IdAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            using (var fs = new FileStream(@"./Data/image.png", FileMode.Open, FileAccess.Read))
            {
                var uploadedAttachment = await tokens.Media.PostAsync(file => fs);

                await Task.Delay(1000);

                var attachment = await tokens.Media.IdAsync(id => uploadedAttachment.Id);

                Assert.NotNull(attachment);
                Assert.Equal(uploadedAttachment.Id, attachment.Id);
                Assert.Equal(uploadedAttachment.PreviewUrl, attachment.PreviewUrl);
                Assert.Equal(uploadedAttachment.Url, attachment.Url);
            }
        }

        [Fact]
        public async Task PutAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            using (var fs = new FileStream(@"./Data/image.png", FileMode.Open, FileAccess.Read))
            {
                var attachment = await tokens.Media.PostAsync(file => fs);

                await Task.Delay(1000);

                var updatedAttachment = await tokens.Media.PutAsync(id => attachment.Id, description => "test");

                Assert.NotNull(updatedAttachment);
                Assert.NotNull(updatedAttachment.PreviewUrl);
                Assert.NotNull(updatedAttachment.Url);
                Assert.Equal("test", updatedAttachment.Description);
            }
        }
    }
}
