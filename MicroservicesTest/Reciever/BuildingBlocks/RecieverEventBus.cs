using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Reciever
{
    public class RecieverEventBus : IDisposable
    {
        private static string message = "";
        ConnectionFactory factory;
        IConnection connection;
        IModel channel;
        bool isDisposed = false;
        public RecieverEventBus()
        {
            if (!isDisposed)
            {
                factory = new ConnectionFactory() { HostName = "localhost" };
                connection = factory.CreateConnection();
                channel = connection.CreateModel();


                channel.QueueDeclare(queue: "sending_test_q",
                                             durable: false,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var msg = Encoding.UTF8.GetString(body.ToArray());
                    message = msg;

                };
                channel.BasicConsume(queue: "sending_test_q",
                                     autoAck: true,
                                     consumer: consumer);
            }

        }
        public string GetCurrentMessage()
        {
            if(!isDisposed)
                return message;
            throw new ObjectDisposedException("object has been disposed");
        }

        public void Dispose()
        {
            isDisposed = true;
            connection.Dispose();
            channel.Dispose();
        }
    }
}