using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Reciever
{
    public static class RecieverEventBus
    {
        public static string message = "";
        static RecieverEventBus()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

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
        public static void Initialize()
        {

        }
    }
}