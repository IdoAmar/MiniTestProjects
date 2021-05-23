using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Sender
{
    public class SenderEventBus
    {
        public SenderEventBus(string message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "sending_test_q",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "",
                                 routingKey: "sending_test_q",
                                 basicProperties: null,
                                 body: body);

        }
    }
}