using TestTask.Domain.ValueObjects;

namespace TestTask.Services.Abstractions
{
    public interface IMouseTrackingService
    {
        Task SaveMouseMovements(List<MouseMovement> mouseMovements);
    }
}
