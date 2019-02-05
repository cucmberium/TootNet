# TootNet

 [![NuGetBadge](https://img.shields.io/nuget/v/TootNet.svg)](https://www.nuget.org/packages/TootNet)

TootNet は.NET Standard向けのマストドンライブラリです。

このライブラリはTwitterライブラリの[CoreTweet](https://github.com/CoreTweet/CoreTweet)と同じようにAPIにアクセスできるように設計されています。

### Sample

[Demo](https://github.com/cucmberium/TootNet/tree/master/TootNet.Demo)が公開されているので基本的なAPIの使い方が学べます。

また、[テストコード](https://github.com/cucmberium/TootNet/tree/master/TootNet.Tests)を参照することでTootNetで使えるすべてのAPIが参照できます。

公式のAPIドキュメントと対応が取れているので[こちら](https://docs.joinmastodon.org/api/)もご参照ください。

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

VisualStudioによるドキュメントのサジェストと公式のドキュメントを組み合わせることですべてのAPIにアクセスすることが可能です。

### Platforms

* .NET Standard

### License

This software is licensed under the MIT License.

このライブラリでは以下のライブラリの一部のコードを使用しています。
* [Mastonet](https://github.com/glacasa/Mastonet)
* [CoreTweet](https://github.com/CoreTweet/CoreTweet)

#### Mastonet

```
MIT License

Copyright (c) 2017 Guillaume Lacasa

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

[https://github.com/glacasa/Mastonet/blob/master/LICENSE](https://github.com/glacasa/Mastonet/blob/master/LICENSE)

#### CoreTweet

```
The MIT License (MIT)

CoreTweet - A .NET Twitter Library supporting Twitter API 1.1
Copyright (c) 2013-2017 CoreTweet Development Team

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
```

[https://github.com/CoreTweet/CoreTweet/blob/master/LICENSE](https://github.com/CoreTweet/CoreTweet/blob/master/LICENSE)

### Other

プルリクエストはいつでも歓迎です！
