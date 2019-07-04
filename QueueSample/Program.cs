using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
namespace QueueSample
{
    public class Program
    {
        public const string connectionstring = "Endpoint=sb://techdiksha.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=WPzEzTSF4UG65nZW0rWsXlTIbokRMGy7UZtJf0CKSns=";
        public const string queueName = "TechQueue";
        static QueueClient queueClient;

        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
            Console.ReadKey();
        }

        static async Task MainAsync()
        {
            queueClient = new QueueClient(connectionstring, queueName);
            await SendMessageToQueue();
            await queueClient.CloseAsync();
        }

        public async static Task SendMessageToQueue()
        {
            for (var i = 0; i < 5; i++)
            {
                // Create a new message to send to the queue.
                string messageBody = $"Message {i}";
                var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                // Write the body of the message to the console.
                Console.WriteLine($"Sending message: {messageBody}");

                // Send the message to the queue.
                await queueClient.SendAsync(message);
            }
        }

    }
}
