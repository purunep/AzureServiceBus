using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace AzureServiceBusReceiver
{
    class Program
    {
        static string connectionString = "Endpoint=sb://purunep.servicebus.windows.net/;SharedAccessKeyName=mypolicy;SharedAccessKey=KXLmjs9x7FobAgjnWaXUq0yFa+0SxtZb34iGUBjhuHA=;";
        static string quepath = "demoqueue";
        static void Main(string[] args)
        {

            var queueClient = new QueueClient(connectionString, quepath);

            queueClient.RegisterMessageHandler(ProcessMessagesAsync, HandleErrorMessageAsync);

            Console.WriteLine("Press enter to exit"); // we need this because message will be receiving in a different thread
            Console.ReadLine();
            queueClient.CloseAsync().Wait();


        }

        private static async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            var content = Encoding.UTF8.GetString(message.Body);
            Console.WriteLine($"Received Message:{content}");
        }

        private static Task HandleErrorMessageAsync(ExceptionReceivedEventArgs arg)
        {
            throw new NotImplementedException();
        }

       
    }
}
