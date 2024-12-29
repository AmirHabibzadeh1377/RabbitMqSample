using RabbitMQ.Client;

namespace RabbitSample.Service
{
    public class RabbitMqBasicService
    {
        protected readonly IConnection _connection;
        protected readonly IChannel _channel;

        public RabbitMqBasicService()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnectionAsync().GetAwaiter().GetResult();
            _channel = _connection.CreateChannelAsync().GetAwaiter().GetResult();
        }
    }
}