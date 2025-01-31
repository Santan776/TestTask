using Moq;
using NUnit.Framework;
using TestTask.DAL.Abstractions;
using TestTask.Models;
using TestTask.Services;

[TestFixture]
public class MouseTrackingServiceTests
{
    private Mock<IMouseTrackingRepository> _mockRepository;
    private MouseTrackingService _service;

    [SetUp]
    public void SetUp()
    {
        _mockRepository = new Mock<IMouseTrackingRepository>();
        _service = new MouseTrackingService(_mockRepository.Object, new Mock<ILogger<MouseTrackingService>>().Object);
    }

    [Test]
    public async Task SaveMouseMovements_ShouldCallSaveAsync_WithAllMovements()
    {
        var movements = new List<MouseMovement>
        {
            new MouseMovement { X = 100, Y = 200, Timestamp = DateTime.Now },
            new MouseMovement { X = 150, Y = 250, Timestamp = DateTime.Now }
        };

        await _service.SaveMouseMovements(movements);

        _mockRepository.Verify(repo => repo.SaveMouseMovements(It.Is<List<MouseMovement>>(m => m.Count == movements.Count &&
            m[0].X == movements[0].X &&
            m[1].X == movements[1].X)), Times.Once);
    }

    [Test]
    public async Task SaveMouseMovements_ShouldNotCallSaveAsync_WhenNoMovements()
    {
        var movements = new List<MouseMovement>();

        await _service.SaveMouseMovements(movements);

        _mockRepository.Verify(repo => repo.SaveMouseMovements(It.IsAny<List<MouseMovement>>()), Times.Never);
    }
}