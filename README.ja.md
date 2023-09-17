# TootNet

 [![NuGetBadge](https://img.shields.io/nuget/v/TootNet.svg)](https://www.nuget.org/packages/TootNet)

TootNet は.NET Standard向けのマストドンライブラリです。

このライブラリはTwitterライブラリの[CoreTweet](https://github.com/CoreTweet/CoreTweet)と同じように直感的にAPIにアクセスできるように設計されています。

### Sample

基本的な使い方は[Demo](https://github.com/cucmberium/TootNet/tree/master/TootNet.Demo)をご覧ください。

また、[テストコード](https://github.com/cucmberium/TootNet/tree/master/TootNet.Tests)には、すべてのAPIの簡易的な使い方が学べます。

TootNetではほぼ公式APIと対応がとれているため[こちら](https://docs.joinmastodon.org/api/)の公式ドキュメントも同様に参考になります。

認証:
```cs
// Create new app
var authorize = new Authorize();
await authorize.CreateApp("mstdn.jp", "yourclientnamehere", Scope.Read | Scope.Write);

// Authorize with code
var authorizeUrl = authorize.GetAuthorizeUri();
Console.WriteLine(authorizeUrl);
var code = Console.ReadLine().Trim();
var tokens = await authorize.AuthorizeWithCode(code);
```

トゥート:
```cs
using (var fs = new FileStream(@"./picture.png", FileMode.Open, FileAccess.Read))
{
    // toot with picture
    var attachment = await tokens.MediaAttachments.PostAsync(file => fs);
    await tokens.Statuses.PostAsync(status => "test toot", visibility => "private", media_ids => new List<long>() { attachment.Id });
}
```

タイムラインの取得:
```cs
var statuses = await tokens.Timelines.HomeAsync(limit => 10);

foreach (var status in statuses)
    Console.WriteLine(status.Content);
```


ReactiveExtensionsを用いたストリーミング:
```cs
Console.OutputEncoding = Encoding.UTF8;

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
```

### Platforms

* .NET Standard

### License

This software is licensed under the MIT License.

このライブラリでは以下のライブラリの一部のコードを使用しています。
* [Mastonet](https://github.com/glacasa/Mastonet)
* [CoreTweet](https://github.com/CoreTweet/CoreTweet)

### Other

プルリクエストはいつでも歓迎です！
