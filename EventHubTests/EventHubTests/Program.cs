using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.EventHubs;
using System.Text;
using System.Threading.Tasks;

namespace EventHubTests
{
    public class Program
    {
        private static EventHubClient eventHubClient;
        public static string filePath = @"c:\temp\testeventhub.txt";
        public static string connectionString = Secretlookup.GetKey(filePath);

        public static EventHubClient BuildConnectionString(string connectionString)
        {
            if(connectionString != null)
            {
                return EventHubClient.CreateFromConnectionString(connectionString);
            }
            else
            {
                return null;
            }
        }
        
        private static async Task MainAsync(string[] args)
        {
            eventHubClient = BuildConnectionString(connectionString);

            await SendMessagesToEventHub(10);

            await eventHubClient.CloseAsync();

            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }

        private static async Task SendMessagesToEventHub(int numMessagesToSend)
        {
            for (var i = 0; i < numMessagesToSend; i++)
            {
                try
                {
                    var message = $"Message {i}";
                    Console.WriteLine($"Sending message: {message}");
                    await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(message)));
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
                }

                await Task.Delay(10);
            }

            Console.WriteLine($"{numMessagesToSend} messages sent.");
        }
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }
    }
}
