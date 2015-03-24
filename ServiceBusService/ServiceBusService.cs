using System;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Microsoft.WindowsAzure;

namespace ServiceBusService
{
    public class ServiceBusService
    {
        private const string QueueName = "TestQueue";
        private static string _connectonString;

        public static void SetConnectionStringInstance()
        {
            _connectonString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
        }

        public static string GetConnectonStringInstance()
        {
            return _connectonString;
        }

        private static void CheckIfExistsQueue(string queueName)
        {
            if (queueName == null) throw new ArgumentNullException("queueName");

            var namespaceManager =
                NamespaceManager.CreateFromConnectionString(_connectonString);

            if (!namespaceManager.QueueExists(queueName))
            {
                namespaceManager.CreateQueue(queueName);
            }
        }


        public static void SendMsg(string msg)
        {
            if (string.IsNullOrEmpty(_connectonString))
            {
                try
                {
                    SetConnectionStringInstance();
                }
                catch (Exception ex)
                {
                    throw new Exception("Set connection string instance exception.", ex);
                }
            }

            CheckIfExistsQueue(QueueName);
            var client = QueueClient.CreateFromConnectionString(_connectonString, QueueName);

            // Create message, passing a string message for the body
            var message = new BrokeredMessage(msg);

            // Set some addtional custom app-specific properties
            message.Properties["TestProperty"] = msg;

            // Send message to the queue
            client.Send(message);
        }

        public static void ReceiveMsg()
        {
            if (string.IsNullOrEmpty(_connectonString))
            {
                try
                {
                    SetConnectionStringInstance();
                }
                catch (Exception ex)
                {
                    throw new Exception("Set connection string instance exception.", ex);
                }

                CheckIfExistsQueue(QueueName);
                var client = QueueClient.CreateFromConnectionString(_connectonString, QueueName);

                // Configure the callback options
                var options = new OnMessageOptions();
                options.AutoComplete = false;
                options.AutoRenewTimeout = TimeSpan.FromMinutes(1);

                // Callback to handle received messages
                client.OnMessage((message) =>
                {
                    try
                    {
                        // Process message from queue
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Received msg from Service Bus");

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Body: " + message.GetBody<string>());
                        Console.WriteLine("MessageID: " + message.MessageId);
                        Console.WriteLine("Test Property: " +
                        message.Properties["TestProperty"]);

                        // Remove message from queue
                        message.Complete();
                        Console.WriteLine("Completed!");
                    }
                    catch (Exception)
                    {
                        // Indicates a problem, unlock message in queue
                        message.Abandon();
                    }
                }, options);

                Console.ReadKey();
            }
        }
    }
}
