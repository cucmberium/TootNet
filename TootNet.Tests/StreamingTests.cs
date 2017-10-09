using System;
using System.Text;
using System.Threading.Tasks;
using TootNet.Streaming;
using Xunit;

namespace TootNet.Tests
{
    public class StreamingTests
    {
        [Fact]
        public async Task UserAsObservableTest()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var tokens = AccountInformation.GetTokens();

            var observable = tokens.Streaming.UserAsObservable();
            var disposable = observable.Subscribe(x =>
            {
                switch (x.Type)
                {
                    case StreamingMessage.MessageType.Status:
                        Console.WriteLine(x.Status.Account.Acct + x.Status.Content);
                        break;
                }
            });

            await Task.Delay(TimeSpan.FromSeconds(30));
            disposable.Dispose();
        }

        [Fact]
        public async Task HashtagAsObservableTest()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var tokens = AccountInformation.GetTokens();

            var observable = tokens.Streaming.HashtagAsObservable(tag => "pixiv");
            var disposable = observable.Subscribe(x =>
            {
                switch (x.Type)
                {
                    case StreamingMessage.MessageType.Status:
                        Console.WriteLine(x.Status.Account.Acct + x.Status.Content);
                        break;
                }
            });

            await Task.Delay(TimeSpan.FromSeconds(30));
            disposable.Dispose();
        }

        [Fact]
        public async Task PublicAsObservableTest()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var tokens = AccountInformation.GetTokens();

            var observable = tokens.Streaming.PublicAsObservable();
            var disposable = observable.Subscribe(x =>
            {
                switch (x.Type)
                {
                    case StreamingMessage.MessageType.Status:
                        Console.WriteLine(x.Status.Account.Acct + x.Status.Content);
                        break;
                }
            });

            await Task.Delay(TimeSpan.FromSeconds(30));
            disposable.Dispose();
        }
    }
}
