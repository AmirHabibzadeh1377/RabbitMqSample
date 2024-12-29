using RabbitMQ.Client;

using rabbitsample.service;

using System.Text;
using System.Threading.Channels;

namespace RabbitSample.Service
{
    public class CosumerServices : RabbitMqBasicService
    {
        public void Consumed()
        {
            var consumer = new customasyncconsumer(_channel);

            
            // شروع مصرف پیام‌ها
            var result = _channel.BasicConsumeAsync(
                queue: "orders",
                autoAck: true,
                consumer: consumer
            ).GetAwaiter().GetResult();


            
            Console.Write(result);
        }
    }
}