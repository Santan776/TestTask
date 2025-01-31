using TestTask.DAL.Abstractions;
using TestTask.Models;
using TestTask.Services.Abstractions;

namespace TestTask.Services
{
    public class MouseTrackingService(IMouseTrackingRepository repo, ILogger<MouseTrackingService> logger) : IMouseTrackingService
    {
        public async Task SaveMouseMovements(List<MouseMovement> mouseMovements)
        {
            try
            {
                if (mouseMovements.Count > 0)
                {
                    await repo.SaveMouseMovements(mouseMovements);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }
    }
}
