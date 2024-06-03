using System.CommandLine;
using System.CommandLine.NamingConventionBinder;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using TootNet.Objects;
using TootNet.Streaming;

namespace TootNet.Demo
{
    class Program
    {
        public static readonly Regex TagRegex = new("""<("[^"]*"|'[^']*'|[^'">])*>""", RegexOptions.Compiled);

        private static async Task Main(string[] args)
        {
            var tootCommand = new Command("toot", "Tooting text")
            {
                new Argument<string>("text", "Input text for toot")
            };
            tootCommand.Handler = CommandHandler.Create<string>(Toot); 

            var homeCommand = new Command("home", "Show home timeline")
            {
                new Option<bool>("--streaming", "Enable streaming")
            };
            homeCommand.Handler = CommandHandler.Create<bool>(Home);

            var notificationCommand = new Command("notification", "Show notifications")
            {
                new Option<bool>("--streaming", "Enable streaming")
            };
            notificationCommand.Handler = CommandHandler.Create<bool>(Notification);

            var ftlCommand = new Command("ftl", "Show federated timeline")
            {
                new Option<bool>("--streaming", "Enable streaming")
            };
            ftlCommand.Handler = CommandHandler.Create<bool>(Ftl);

            var ltlCommand = new Command("ltl", "Show local timeline")
            {
                new Option<bool>("--streaming", "Enable streaming")
            };
            ltlCommand.Handler = CommandHandler.Create<bool>(Ltl);

            var rootCommand = new RootCommand
            {
                tootCommand,
                homeCommand,
                notificationCommand,
                ftlCommand,
                ltlCommand,
            };

            rootCommand.Description = "TootNet demo app";

            await rootCommand.InvokeAsync(args);
        }

        private static async Task Toot(string text)
        {
            var tokens = await GetTokens();

            var status = await tokens.Statuses.PostAsync(status => text.Trim());

            ShowStatus(status);
        }

        private static async Task Home(bool streaming)
        {
            var tokens = await GetTokens();

            var statuses = await tokens.Timelines.HomeAsync();
            statuses.Reverse();

            foreach (var status in statuses)
            {
                ShowStatus(status);
            }

            if (!streaming)
            {
                return;
            }

            var observable = tokens.WebSocketStreaming.UserAsObservable();
            var disposable = observable.Subscribe(x =>
            {
                switch (x.Type)
                {
                    case StreamingMessage.MessageType.Status:
                        ShowStatus(x.Status);
                        break;
                }
            });

            await Task.Delay(Timeout.Infinite);
            disposable.Dispose();
        }

        private static async Task Notification(bool streaming)
        {
            var tokens = await GetTokens();

            var notifications = await tokens.Notifications.GetAsync();
            notifications.Reverse();

            foreach (var notification in notifications)
            {
                ShowNotification(notification);
            }

            if (!streaming)
            {
                return;
            }

            var observable = tokens.WebSocketStreaming.UserNotificationAsObservable();
            var disposable = observable.Subscribe(x =>
            {
                switch (x.Type)
                {
                    case StreamingMessage.MessageType.Notification:
                        ShowNotification(x.Notification);
                        break;
                }
            });

            await Task.Delay(Timeout.Infinite);
            disposable.Dispose();
        }

        private static async Task Ftl(bool streaming)
        {
            var tokens = await GetTokens();

            var statuses = await tokens.Timelines.PublicAsync();
            statuses.Reverse();

            foreach (var status in statuses)
            {
                ShowStatus(status);
            }

            if (!streaming)
            {
                return;
            }

            var observable = tokens.WebSocketStreaming.PublicAsObservable();
            var disposable = observable.Subscribe(x =>
            {
                switch (x.Type)
                {
                    case StreamingMessage.MessageType.Status:
                        ShowStatus(x.Status);
                        break;
                }
            });

            await Task.Delay(Timeout.Infinite);
            disposable.Dispose();
        }

        private static async Task Ltl(bool streaming)
        {
            var tokens = await GetTokens();

            var statuses = await tokens.Timelines.PublicAsync(local => true);
            statuses.Reverse();

            foreach (var status in statuses)
            {
                ShowStatus(status);
            }

            if (!streaming)
            {
                return;
            }

            var observable = tokens.WebSocketStreaming.PublicLocalAsObservable();
            var disposable = observable.Subscribe(x =>
            {
                switch (x.Type)
                {
                    case StreamingMessage.MessageType.Status:
                        ShowStatus(x.Status);
                        break;
                }
            });

            await Task.Delay(Timeout.Infinite);
            disposable.Dispose();
        }

        private static void ShowStatus(Status status)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine(status.Account.DisplayName + "\t\t" + status.Account.Acct);
            if (status.Reblog != null)
            {
                Console.WriteLine("reblog");
                Console.WriteLine("\t====================");
                Console.WriteLine("\t" + status.Reblog.Account.DisplayName + "\t\t" +
                                  status.Reblog.Account.Acct);
                Console.WriteLine("\t" + TagRegex
                    .Replace(status.Reblog.Content.Replace("<br />", "\n"), "").Trim());
                Console.WriteLine("\t====================");
            }
            else
            {
                Console.WriteLine(TagRegex.Replace(status.Content.Replace("<br />", "\n"), "").Trim());
            }
            Console.WriteLine(status.CreatedAt);
            Console.WriteLine("--------------------");
        }

        private static void ShowNotification(Notification notification)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine(notification.Account.DisplayName + "\t\t" + notification.Account.Acct);
            Console.WriteLine(notification.Type);
            if (notification.Type is "mention" or "reblog" or "favourite")
            {
                Console.WriteLine("\t====================");
                Console.WriteLine("\t" + notification.Status.Account.DisplayName + "\t\t" +
                                  notification.Status.Account.Acct);
                Console.WriteLine("\t" + TagRegex
                    .Replace(notification.Status.Content.Replace("<br />", "\n"), "").Trim());
                Console.WriteLine("\t====================");
            }
            Console.WriteLine(notification.CreatedAt);
            Console.WriteLine("--------------------");
        }
        private static async Task<Tokens> GetTokens()
        {
            var configPath = GetConfigFilePath("config.json");
            if (string.IsNullOrEmpty(configPath))
            {
                throw new System.Exception("Cannot detect platform");
            }
            if (!File.Exists(configPath))
            {
                var tokens = await Authorize(configPath);
                var config = new Config { AccessToken = tokens.AccessToken, ClientId = tokens.ClientId, ClientSecret = tokens.ClientSecret, Instance = tokens.Instance };
                await File.WriteAllTextAsync(configPath, JsonConvert.SerializeObject(config, Formatting.Indented));
                return tokens;
            }
            else
            {
                var config = JsonConvert.DeserializeObject<Config>(await File.ReadAllTextAsync(configPath));
                if (config == null)
                {
                    File.Delete(configPath);
                    throw new System.Exception("Invalid config file");
                }
                var tokens = new Tokens(config.Instance, config.AccessToken, config.ClientId, config.ClientSecret);

                return tokens;
            }
        }

        private static async Task<Tokens> Authorize(string configPath)
        {
            var authorize = new Authorize();

            Console.Write("instance: ");
            var instance = (Console.ReadLine()?.Trim()) ?? throw new System.Exception("Invalid instance specified");
            await authorize.CreateApp(instance, "Tootnet", Scope.Read | Scope.Write);

            var authorizeUrl = authorize.GetAuthorizeUri();
            Console.WriteLine(authorizeUrl);
            Console.Write("code: ");
            var code = (Console.ReadLine()?.Trim()) ?? throw new System.Exception("Invalid instance code");

            var tokens = await authorize.AuthorizeWithCode(code);

            return tokens;
        }

        private static string? GetConfigFilePath(string fileName)
        {
            string folderPath;

            if (OperatingSystem.IsWindows())
            {
                folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TootNet");
            }
            else if (OperatingSystem.IsLinux())
            {
                folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".config", "TootNet");
            }
            else if (OperatingSystem.IsMacOS())
            {
                folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Library", "Application Support", "TootNet");
            }
            else
            {
                return null;
            }

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            return Path.Combine(folderPath, fileName);
        }
    }

    internal class Config
    {
        public required string Instance { get; set; }

        public required string ClientId { get; set; }

        public required string ClientSecret { get; set; }

        public required string AccessToken { get; set; }
    }
}
