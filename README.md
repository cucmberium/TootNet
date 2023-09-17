﻿# TootNet

 [![NuGetBadge](https://img.shields.io/nuget/v/TootNet.svg)](https://www.nuget.org/packages/TootNet)

日本語のREADMEは[こちら](https://github.com/cucmberium/TootNet/tree/master/README.ja.md)

TootNet is a Mastodon library for .NET Standard.

This library is designed to intuitively access the API in the same way as the Twitter library [CoreTweet](https://github.com/CoreTweet/CoreTweet).

### Sample

For basic usage, please refer to the [Demo](https://github.com/cucmberium/TootNet/tree/master/TootNet.Demo).

Also, the [test code](https://github.com/cucmberium/TootNet/tree/master/TootNet.Tests) provides simple usage for all APIs.

Since TootNet is almost compatible with the official API, the [official documentation](https://docs.joinmastodon.org/api/) is also a useful reference.

Authorizing:
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

Tooting:
```cs
using (var fs = new FileStream(@"./picture.png", FileMode.Open, FileAccess.Read))
{
    // toot with picture
    var attachment = await tokens.MediaAttachments.PostAsync(file => fs);
    await tokens.Statuses.PostAsync(status => "test toot", visibility => "private", media_ids => new List<long>() { attachment.Id });
}
```

Getting timelines:
```cs
var statuses = await tokens.Timelines.HomeAsync(limit => 10);

foreach (var status in statuses)
    Console.WriteLine(status.Content);
```


Streaming using reactive extensions:
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

This library uses part of the codes of the following libraries.
* [Mastonet](https://github.com/glacasa/Mastonet)
* [CoreTweet](https://github.com/CoreTweet/CoreTweet)

### Other

Pull requests are welcome!
