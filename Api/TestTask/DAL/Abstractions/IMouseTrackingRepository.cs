using TestTask.Models;

namespace TestTask.DAL.Abstractions
{
    public interface IMouseTrackingRepository
    {
        Task SaveMouseMovements(List<MouseMovement> mouseMovements);
    }
}
