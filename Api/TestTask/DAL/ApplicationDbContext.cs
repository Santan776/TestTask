using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<MouseMovement> MouseMovements { get; set; }
    }
}
