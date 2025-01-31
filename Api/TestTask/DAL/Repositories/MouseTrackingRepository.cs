using Microsoft.EntityFrameworkCore;
using TestTask.DAL.Abstractions;
using TestTask.Models;

namespace TestTask.DAL.Repositories
{
    public class MouseTrackingRepository(ApplicationDbContext context) : IMouseTrackingRepository
    {
        public async Task SaveMouseMovements(List<MouseMovement> mouseMovements)
        {
            foreach (var m in mouseMovements)
            {
                context.MouseMovements.Add(m);
            }
            await context.SaveChangesAsync();
        }
    }
}
