using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using System.Net.Http;

namespace Webhook_Spammer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Webhook Spammer by TERI#6116";
            if (!File.Exists(Environment.CurrentDirectory + "\\webhook.txt"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Webhook.txt or Message.txt files are missing!");
                Console.ResetColor();
                Console.WriteLine("\nPress any key to Exit...");
                Console.ReadKey();
                return; // It makes it ignore the below code, because without the files, the spammer can't run.
            }

            // This is your webhook you want to spam to. (It's in the webhook.txt)
            var webHook = File.ReadAllText(Environment.CurrentDirectory + "\\webhook.txt"); // Put your webhook in the webhook.txt file.
            var message = File.ReadAllText(Environment.CurrentDirectory + "\\message.txt"); // This is the message you want to spam. (Markdown supported)
            var timesToSpam = 0; // How many times you want to spam it, 0 = 999999999. (Infinite [and 999999999 is max])

            Spam(webHook, message, timesToSpam);
        }

        static void Spam(string hook, string msg, int timeToSpam)
        {
            var spam = new NameValueCollection();
            using (var wc = new WebClient())
            {
                spam["content"] = msg; // We set the content of the ValueCollection to the message variable. (string)

                if (timeToSpam == 0) // If the timesToSpam variable is equal to 0, it's going to change it to 999999999, unnecessary, but it's easier to just put in a 0.
                {
                    timeToSpam = 999999999;
                }

                for (int i = 0; i < timeToSpam; i++) // Make it repeat.
                {
                    Task.Delay(150); // Wait again
                    try
                    {
                        Task.Delay(150); // Make it wait for 150 milliseconds so it won't keep failing because of too many sent requests. (It's to give it rest)
                        wc.UploadValues(hook, spam); // This is where it sends the values.
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("V | Message sent to Webhook successfully.");
                        Console.Title = "Webhook Spammer by TERI#6116 | Success!";
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("X | Failed to send message to Webhook, Retrying..."); // It will run the whole thing again.
                        Console.Title = "Webhook Spammer by TERI#6116 | Failed, Retrying...";

                        // Since it will fail a lot if you spam it too much, I'm going to add another way so it will keep spamming successfully.
                        using (var client = new HttpClient())
                        {
                            for (int _i = 0; _i < timeToSpam; _i++) // Make it repeat.
                            {
                                try
                                {
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
                                }
                                catch
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("X | Failed to send message to Webhook, Retrying..."); // It will run the whole thing again.
                                    Console.Title = "Webhook Spammer by TERI#6116 | Failed, Retrying...";
                                    Spam(hook, msg, timeToSpam);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
