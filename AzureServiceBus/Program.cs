using System;
using System.Text;
using Microsoft.Azure.ServiceBus;

namespace AzureServiceBus
{
    class Program
    {
        static string connectionString = "Endpoint=sb://purunep.servicebus.windows.net/;SharedAccessKeyName=mypolicy;SharedAccessKey=KXLmjs9x7FobAgjnWaXUq0yFa+0SxtZb34iGUBjhuHA=;";
        static string quepath = "demoqueue";
        static void Main(string[] args)
        {
            var queueClient = new QueueClient(connectionString, quepath);
            for(int i=0;i<20;i++)
            {
                var data = $"Data: {i}";
                var message = new Message(Encoding.UTF8.GetBytes(data));
                queueClient.SendAsync(message).Wait();
                Console.WriteLine($"Data sent: {i}");
            }
            queueClient.CloseAsync().Wait();
            Console.WriteLine("Message sent");
            Console.ReadLine();
            
        }
    }
}
