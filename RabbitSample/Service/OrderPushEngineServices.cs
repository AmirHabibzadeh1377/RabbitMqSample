using RabbitMQ.Client;
using System.Text;

namespace RabbitSample.Service
{
    public  class OrderPushEngineServices : RabbitMqBasicService
    {
        public  async Task<bool> PushMessage(string message)
        {
            await _channel.QueueDeclareAsync(queue: "orders", durable: true, exclusive: false, autoDelete: false, arguments: null);
            var body = Encoding.UTF8.GetBytes(message);
           await _channel.BasicPublishAsync(exchange:"",routingKey:"orders",body);
            
            return true;
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}