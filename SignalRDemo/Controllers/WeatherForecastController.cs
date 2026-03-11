using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalRDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public NotificationController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send([FromBody] string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
            return Ok(new { success = true, sentMessage = message });
        }
    }
}
