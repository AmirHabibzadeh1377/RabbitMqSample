using RabbitMQ.Client;
using System.Text;

namespace RabbitSample.Service
{
    public static class OrderPushEngineServices
    {
        public static async Task<bool> PushMessage(string message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            var connection = await factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: "orders", durable: true, exclusive: false, autoDelete: false, arguments: null);
            var body = Encoding.UTF8.GetBytes(message);
            await channel.BasicPublishAsync(exchange:"",routingKey:"orders",body);
            return true;
        }
    }
}