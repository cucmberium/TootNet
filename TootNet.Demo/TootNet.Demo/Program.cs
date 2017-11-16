using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TootNet.Demo
{
    class Program
    {
        public static readonly Regex TagRegex =
            new Regex(@"<(""[^""]*""|'[^']*'|[^'"">])*>", RegexOptions.Compiled);

        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            var authorize = new Authorize();
            await authorize.CreateApp("mstdn.jp", "Tootnet", Scope.Read | Scope.Write | Scope.Follow);

            var authorizeUrl = authorize.GetAuthorizeUri();
            Console.WriteLine(authorizeUrl);
            Console.Write("code: ");
            var code = Console.ReadLine().Trim();
            var tokens = await authorize.AuthorizeWithCode(code);

            Console.WriteLine(" -- List of commands -- ");
            Console.WriteLine("toot [status]");
            Console.WriteLine("notification");
            Console.WriteLine("home");
            Console.WriteLine("ftl");
            Console.WriteLine("ltl");
            Console.WriteLine("help");
            Console.WriteLine("quit");
            Console.WriteLine("exit");

            while (true)
            {
                Console.Write("command: ");
                var command = Console.ReadLine().Trim().Split(' ', 2);
                switch (command.First().ToLower())
                {
                    case "help":
                        Console.WriteLine(" -- List of commands -- ");
                        Console.WriteLine("toot [status]");
                        Console.WriteLine("notification");
                        Console.WriteLine("home");
                        Console.WriteLine("ftl");
                        Console.WriteLine("ltl");
                        Console.WriteLine("help");
                        Console.WriteLine("quit");
                        Console.WriteLine("exit");
                        break;

                    case "quit":
                    case "exit":
                        return;

                    case "toot":
                        if (command.Length <= 1)
                            break;
                        
                        var post = await tokens.Statuses.PostAsync(status => command[1].Trim());

                        Console.WriteLine("--------------------");
                        Console.WriteLine(post.Account.DisplayName + "\t\t" + post.Account.Acct);
                        Console.WriteLine(TagRegex.Replace(post.Content.Replace("<br />", "\n"), "").Trim());
                        Console.WriteLine(post.CreatedAt);
                        Console.WriteLine("--------------------");
                        break;

                    case "home":
                        var home = await tokens.Timelines.HomeAsync();
                        Console.WriteLine("--------------------");
                        foreach (var status in home)
                        {
                            Console.WriteLine(status.Account.DisplayName + "\t\t" + status.Account.Acct);
                            Console.WriteLine(TagRegex.Replace(status.Content.Replace("<br />", "\n"), "").Trim());
                            Console.WriteLine(status.CreatedAt);
                            Console.WriteLine("--------------------");
                        }
                        break;

                    case "ftl":
                        var ftl = await tokens.Timelines.PublicAsync();
                        Console.WriteLine("--------------------");
                        foreach (var status in ftl)
                        {
                            Console.WriteLine(status.Account.DisplayName + "\t\t" + status.Account.Acct);
                            Console.WriteLine(TagRegex.Replace(status.Content.Replace("<br />", "\n"), "").Trim());
                            Console.WriteLine(status.CreatedAt);
                            Console.WriteLine("--------------------");
                        }
                        break;

                    case "ltl":
                        var ltl = await tokens.Timelines.PublicAsync(local => true);
                        Console.WriteLine("--------------------");
                        foreach (var status in ltl)
                        {
                            Console.WriteLine(status.Account.DisplayName + "\t\t" + status.Account.Acct);
                            Console.WriteLine(TagRegex.Replace(status.Content.Replace("<br />", "\n"), "").Trim());
                            Console.WriteLine(status.CreatedAt);
                            Console.WriteLine("--------------------");
                        }
                        break;

                    case "notification":
                        var notifications = await tokens.Notifications.GetAsync();
                        Console.WriteLine("--------------------");
                        foreach (var notification in notifications)
                        {
                            Console.WriteLine(notification.Account.DisplayName + "\t\t" + notification.Account.Acct);
                            Console.WriteLine(notification.Type);
                            if (notification.Type == "mention" || notification.Type == "reblog" ||
                                notification.Type == "favourite")
                            {
                                Console.WriteLine("==========");
                                Console.WriteLine(notification.Status.Account.DisplayName + "\t\t" +
                                                  notification.Status.Account.Acct);
                                Console.WriteLine(TagRegex
                                    .Replace(notification.Status.Content.Replace("<br />", "\n"), "").Trim());
                                Console.WriteLine("==========");
                            }
                            Console.WriteLine(notification.CreatedAt);
                            Console.WriteLine("--------------------");
                        }
                        break;
                }
            }
        }
    }
}