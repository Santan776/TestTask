using TestTask.Models;

namespace TestTask.Services.Abstractions
{
    public interface IMouseTrackingService
    {
        Task SaveMouseMovements(List<MouseMovement> mouseMovements);
    }
}
