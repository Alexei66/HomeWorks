using SeaBattle.Logic;
using SeaBattle.Logic.Ships;

namespace Tests;

public class ShipPointTests
{
    [Fact]
    public void Print_WhenSPExist_ShouldReturnValidState()
    {
        // Arrange
        var shipPoint = new ShipPoint(new Point(0, 0), new Military(1, Guid.NewGuid()));

        // Act

        // Assert
    }

    // TODO Валидный принт
    // TODO неВалидный принт
}