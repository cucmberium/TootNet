using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TootNet.Tests
{
    public class BookmarksTests
    {
        [Fact]
        public async Task GetAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();
            
            await tokens.Bookmarks.BookmarkAsync(id => 110640658973976934);

            await Task.Delay(1000);

            var bookmarks = await tokens.Bookmarks.GetAsync();

            Assert.NotEmpty(bookmarks);
            Assert.Contains(bookmarks, x => x.Id == 110640658973976934);

            await Task.Delay(1000);

            await tokens.Bookmarks.UnbookmarkAsync(id => 110640658973976934);
        }

        [Fact]
        public async Task BookmarkAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            await tokens.Bookmarks.BookmarkAsync(id => 110640658973976934);

            await Task.Delay(1000);

            var bookmarks = await tokens.Bookmarks.GetAsync();

            Assert.NotEmpty(bookmarks);
            Assert.Contains(bookmarks, x => x.Id == 110640658973976934);

            await Task.Delay(1000);

            await tokens.Bookmarks.UnbookmarkAsync(id => 110640658973976934);
        }

        [Fact]
        public async Task UnblockAsyncTest()
        {
            var tokens = AccountInformation.GetTokens();

            await tokens.Bookmarks.UnbookmarkAsync(id => 110640658973976934);

            await Task.Delay(1000);

            var bookmarks = await tokens.Bookmarks.GetAsync();

            Assert.DoesNotContain(bookmarks, x => x.Id == 110640658973976934);
        }
    }
}
