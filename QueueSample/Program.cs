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
        public const string connectionstring = "<Connection string of service bus>";
        public const string queueName = "<Name of the queue>";
        static QueueClient queueClient;

        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
            Console.ReadKey();
        }

        static async Task MainAsync()
        {
            //Creating Client for the Queue.
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

                // Write the body of the message to the console which is to be send to queue.
                Console.WriteLine($"Sending message: {messageBody}");

                // Send the message to the queue.
                await queueClient.SendAsync(message);
            }
        }

    }
}
