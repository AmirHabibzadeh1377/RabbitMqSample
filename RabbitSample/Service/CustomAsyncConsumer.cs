using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System.Text;
using System.Threading;

namespace rabbitsample.service
{
    public class customasyncconsumer : AsyncDefaultBasicConsumer
    {
        public customasyncconsumer(IChannel channel) : base(channel)
        {
        }

        public override async Task HandleBasicDeliverAsync(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IReadOnlyBasicProperties properties, ReadOnlyMemory<byte> body, CancellationToken cancellationToken = default)
        {
            var message = Encoding.UTF8.GetString(body.ToArray());
            Console.WriteLine($"[x] Received: {message}");

            // شبیه‌سازی پردازش پیام
            await Task.Delay(1000);
            await base.HandleBasicDeliverAsync(consumerTag, deliveryTag, redelivered, exchange, routingKey, properties, body, cancellationToken);
        }
    }
}