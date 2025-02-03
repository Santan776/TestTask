using Microsoft.AspNetCore.Mvc;
using TestTask.Domain.ValueObjects;
using TestTask.Services.Abstractions;

namespace MouseTrackingApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MouseMovementController(IMouseTrackingService mouseTrackingService) : ControllerBase
    {

        [HttpPost("mousemovement")]
        public async Task<IActionResult> PostMouseMovement([FromBody] List<MouseMovement> mouseMovement)
        {
            if (mouseMovement == null)
                return BadRequest();
            
            await mouseTrackingService.SaveMouseMovements(mouseMovement);

            return Ok();
        }
    }
}