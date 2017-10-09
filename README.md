# TootNet

 [![NuGetBadge](https://img.shields.io/nuget/v/TootNet.svg)](https://www.nuget.org/packages/TootNet)

日本語のREADMEは[こちら](https://github.com/cucmberium/TootNet/tree/master/README.ja.md)

TootNet is Mastodon library for .NET Standard.

This library is designed to access the API just like the Twitter library [CoreTweet](https://github.com/CoreTweet/CoreTweet).

### Sample

You can see example at [TootNet test code](https://github.com/cucmberium/TootNet/tree/master/TootNet.Tests).
Official api list is available [here](https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md).

Authorizing:
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

Tooting:
```cs
using (var fs = new FileStream(@"./picture.png", FileMode.Open, FileAccess.Read))
{
    // toot with picture
    var attachment = await tokens.Media.PostAsync(file => fs);
    await tokens.Statuses.PostAsync(status => "test toot", visibility => "private", media_ids => new List() { attachment.Id });
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

You can easily use API by official documentation and parameter suggestion by VisualStudio.

### Platforms

* .NET Standard

### License

This software is licensed under the MIT License.

This library uses part of the codes of the following libraries.
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

Pull requests are welcome!
