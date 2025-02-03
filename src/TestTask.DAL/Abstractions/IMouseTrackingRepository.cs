using TestTask.Domain.ValueObjects;

namespace TestTask.DAL.Abstractions
{
    public interface IMouseTrackingRepository
    {
        Task SaveMouseMovements(List<MouseMovement> mouseMovements);
    }
}
