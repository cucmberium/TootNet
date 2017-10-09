# TootNet
--

TootNet は.NET Standard向けのマストドンライブラリです。

### Sample

[テストコード](https://github.com/cucmberium/TootNet/tree/master/TootNet.Tests)を参照することでTootNetで使えるすべてのAPIが参照できます。
公式のAPIドキュメントと対応が取れているので[こちら](https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md)もご参照ください。

認証:
```cs
// Create new app
var authorize = new Authorize();
await authorize.CreateApp("mstdn.jp", "yourclientnamehere", Scope.Read | Scope.Write | Scope.Follow);

// Authorize with code
var authorizeUrl = authorize.GetAuthorizeUri();
Console.WriteLine(authorizeUrl);
var code = Console.ReadLine().Trim();
var tokens = await authorize.AuthorizeWithCode(code);

// Or you can use password authorization
var tokens = await authorize.AuthorizeWithEmail("username", "password");
```

トゥート:
```cs
using (var fs = new FileStream(@"./picture.png", FileMode.Open, FileAccess.Read))
{
    // toot with picture
    var attachment = await tokens.Media.PostAsync(file => fs);
    await tokens.Statuses.PostAsync(status => "test toot", visibility => "private", media_ids => new List() { attachment.Id });
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

VisualStudioによるドキュメントのサジェストと公式のドキュメントを組み合わせることで、
すべてのAPIにアクセスすることが可能です。

### Platforms

* .NET Standard

### License

This software is licensed under the MIT License.

このライブラリでは以下のライブラリの一部のコードを使用しています。
* Mastonet
* CoreTweet

### Other

プルリクエストはいつでも歓迎してます
