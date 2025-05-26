using Contracts;
using Microsoft.AspNetCore.Mvc;
using Producer.Services;

namespace Producer
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagingController : ControllerBase
    {
        private readonly IMessagePublisher _messagePublisher;

        public MessagingController(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }

        [HttpPost("publish/customer")]
        public async Task<IActionResult> PublishCustomer([FromBody] CustomerCreated request)
        {
            await _messagePublisher.Publish(request);
            return Ok();
        }

        [HttpPost("publish/order")]
        public async Task<IActionResult> PublishOrder([FromBody] OrderCreated request)
        {
            await _messagePublisher.Publish(request);
            return Ok();
        }
    }
}
