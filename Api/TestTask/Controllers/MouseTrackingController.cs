using Microsoft.AspNetCore.Mvc;
using TestTask.Models;
using TestTask.DAL;

namespace MouseTrackingApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MouseMovementController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MouseMovementController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("mousemovement")]
        public async Task<IActionResult> PostMouseMovement([FromBody] List<MouseMovement> mouseMovement)
        {
            if (mouseMovement == null)
                return BadRequest();
            
            foreach(var m in mouseMovement)
            {
                _context.MouseMovements.Add(m);
            }
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}