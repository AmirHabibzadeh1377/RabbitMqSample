using Microsoft.AspNetCore.Mvc;
using RabbitSample.Service;

namespace RabbitSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        [HttpGet]
        public IActionResult SendMessage(string messages)
        {
            var rabbitService = new OrderPushEngineServices();
            var result = rabbitService.PushMessage(messages);
            rabbitService.Dispose();
            return Ok(messages);
        }

        [HttpGet]
        public IActionResult Ack()
        {
            var consumer = new CosumerServices();
            consumer.Consumed();
            return Ok();
        }
    }
}
