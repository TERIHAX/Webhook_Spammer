using System;
using System.Collections.Generic;
using System.Net;
using System.Collections.Specialized;
using System.Net.Http;

namespace Webhook_Spammer
{
    class Program
    {
        public static NameValueCollection spam = new NameValueCollection();

        static void Main(string[] args)
        {
            Console.Title = "Webhook Spammer by TERI#6116";

            string userName;
            string message;
            string avatar;
            string webHook;
            int timesToSpam = 999999999; // 999999999 is max.

            Console.WriteLine("* = Required\n\nUsername: Press Enter for the default Webhook username.");
            userName = Console.ReadLine();
            if (userName.ToUpperInvariant() == "NONE" || userName.ToUpperInvariant() == " " || userName.ToUpperInvariant() == "" || userName.ToUpperInvariant() == null)
            {
                
            }
            else
            {
                spam["username"] = userName;
            }

            Console.WriteLine("\nMessage: *");
            message = Console.ReadLine();

            void idkwhattocallthis_v1() // I can't think of any name lol.
            {
                if (message == "" || message == " " || message == null)
                {
                    Console.WriteLine("\nThat is not a valid message, try again.");
                    Console.WriteLine("\nMessage: * Required");
                    message = Console.ReadLine();
                    idkwhattocallthis_v1();
                }
                else
                {
                    spam["content"] = message;
                }
            }

            idkwhattocallthis_v1();

            Console.WriteLine("\nAvatar: Press Enter for the default Webhook avatar.");
            avatar = Console.ReadLine();
            void idkwhattocallthis_v2() // Idk what to call these.
            {
                if (avatar.ToUpperInvariant() == "NONE" || avatar.ToUpperInvariant() == " " || avatar.ToUpperInvariant() == "" || avatar.ToUpperInvariant() == null)
                {
                    
                }
                else if (!avatar.ToUpperInvariant().StartsWith("http://") || !avatar.ToUpperInvariant().StartsWith("https://"))
                {
                    Console.WriteLine("\nLinks must start with \"http://\" or \"https://\", try again.");
                    Console.WriteLine("\nAvatar: Press Enter for the default Webhook avatar.");
                    avatar = Console.ReadLine();
                    idkwhattocallthis_v2();
                }
                else
                {
                    spam["avatar_url"] = avatar;
                }
            }

            idkwhattocallthis_v2();

            Console.WriteLine("\nWebhook: *");
            webHook = Console.ReadLine();
            void idkwhattocallthis_v3() // Idk what to call these.
            {
                if (!webHook.ToUpperInvariant().StartsWith("http://") || !webHook.ToUpperInvariant().StartsWith("https://"))
                {
                    Console.WriteLine("\nLinks must start with \"http://\" or \"https://\", try again.");
                    Console.WriteLine("\nWebhook: *");
                    webHook = Console.ReadLine();
                    idkwhattocallthis_v3();
                }
            }

            idkwhattocallthis_v3();

            Console.WriteLine("\nSpam Log:");
            Spam(webHook, message, timesToSpam);
        }

        static void Spam(string hook, string msg, int timeToSpam)
        {
            string returnString()
            {
                return new WebClient().DownloadString(hook);
            }

            using (var wc = new WebClient())
            {
                for (int i = 0; i < timeToSpam; i++) // Make it repeat.
                {
                    for (int __i = 0; __i < timeToSpam; __i++) // Make it double times so it's 1999999998 times to spam.
                    {
                        try
                        {
                            if (new WebClient().DownloadString(hook).ToUpperInvariant().Contains("10015"))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"X | Failed to send message to Webhook, Error: {returnString()}");
                                Console.ResetColor();
                                Console.WriteLine("\nPress any key to Exit...");
                                Console.ReadKey();
                                return;
                            }

                            wc.UploadValues(hook, spam); // This is where it sends the values.
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("V | Message sent to Webhook successfully.");
                            Console.Title = "Webhook Spammer by TERI#6116 | Success!";

                            Spam(hook, msg, timeToSpam);
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("X | Failed to send message to Webhook, Retrying..."); // It will run the whole thing again.
                            Console.Title = "Webhook Spammer by TERI#6116 | Failed, Retrying...";

                            // Since it will fail a lot if you spam it too much, I'm going to add another way so it will keep spamming successfully.
                            using (var client = new HttpClient())
                            {
                                for (int _i = 0; _i < 3; _i++) // Make it repeat 3 times.
                                {
                                    try
                                    {
                                        if (new WebClient().DownloadString(hook).ToUpperInvariant().Contains("\"CODE\"") || new WebClient().DownloadString(hook).ToUpperInvariant().Contains("10015") || new WebClient().DownloadString(hook).ToUpperInvariant().Contains("\"UNKNOWN\""))
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine($"X | Failed to send message to Webhook, Error: {returnString()}");
                                            Console.ResetColor();
                                            Console.WriteLine("\nPress any key to Exit...");
                                            Console.ReadKey();
                                            return;
                                        }

                                        Dictionary<string, string> dict = new Dictionary<string, string>
                                    {
                                        {
                                            "content",
                                            string.Concat(new string[]
                                            {
                                                msg
                                            })
                                        }
                                    };
                                        client.PostAsync(hook, new FormUrlEncodedContent(dict)).GetAwaiter().GetResult();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("V | Message sent to Webhook successfully.");
                                        Console.Title = "Webhook Spammer by TERI#6116 | Success!";

                                        Spam(hook, msg, timeToSpam);
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("X | Failed to send message to Webhook, Retrying..."); // It will run the whole thing again.
                                        Console.Title = "Webhook Spammer by TERI#6116 | Failed, Retrying...";

                                        Spam(hook, msg, timeToSpam); // Repeat it again.
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
