using FluentAssertions;
using SeaBattle.Logic;
using SeaBattle.Logic.Ships;
using System.Text;
using Xunit.Sdk;

namespace Tests
{
    public class BattlefieldTests
    {
        private Battlefield CreateBattlefield(int size)
        {
            return new Battlefield(size);
        }

        [Fact]
        public void Ctor_WhenSizeOdd_ShouldCreatNewBF()
        {
            // Arrange

            var size = 11;
            var expSize = size * size;

            // Act
            var battlefield = this.CreateBattlefield(size);

            // Assert
            battlefield.Should().NotBeNull();

            battlefield.Points.Should().NotBeNullOrEmpty();

            battlefield.Points.Count.Should().Be(expSize);
        }

        [Fact]
        public void Ctor_WhenSizeEven_ShouldThrowExeption()
        {
            // Arrange

            var size = 10;
            var expSize = size * size;

            // Act
            var act = () => CreateBattlefield(size);

            // Assert
            Assert.Throws<Exception>(act).Message.Should().Be("четное число");
        }

        [Fact]
        public void AddShip_WhenShipAdded_ExpectedNewShip()
        {
            // Arrange
            var battlefield = this.CreateBattlefield(11);
            Point startPosition = new Point(-1, 0);
            Point finishPosition = new Point(-1, 1);
            Ship ship = new Military(20);

            // Act
            battlefield.AddShip(
                startPosition,
                finishPosition,
                ship);

            // Assert
            battlefield.Points.Count.Should().Be(121);

            battlefield.Ships.Count.Should().Be(1);
        }

        [Fact]
        public void AddShip_When1PointShipAdded_ExpectedNewPointShip()
        {
            // Arrange
            var battlefield = this.CreateBattlefield(11);
            Point startPosition = new Point(0, 0);

            Ship ship = new Military(20);

            // Act
            battlefield.AddShip(startPosition, ship);

            // Assert
            var expShip = battlefield[Quadrant.I, startPosition.XAbs, startPosition.YAbs];

            expShip.Should().NotBeNull();

            expShip.Length.Should().Be(1);

            battlefield.Ships.Count.Should().Be(1);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] {new Point(-100,10),new Point(1,1),"За пределами поля"},
            new object[] {new Point(1,1),new Point(1,120),"За пределами поля"},

            new object[] {new Point(0,0),new Point(0,0),"Пересечение кораблей"},

            new object[] {new Point(2,2),new Point(1,1),"Диагональный корабль"},
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void AddShip_WhenInvalidShipAdded_ShouldThrowExep(Point startPosition, Point finishPosition, string expectedMessage)
        {
            // Arrange
            var battlefield = this.CreateBattlefield(5);

            Ship ship = new Military(20);
            battlefield.AddShip(new Point(0, 0), new Point(0, 0), ship);
            // Act
            var act = () => battlefield.AddShip(
                startPosition,
                finishPosition,
                ship);

            // Assert
            Assert.Throws<Exception>(act).Message.Should().Be(expectedMessage); //
        }

        [Fact]
        public void Print_WhenShipExists_ShoulReturnBFState()
        {
            // Arrange

            var point = new Point(0, 0);
            var ship = new Military(20);
            var sp = new ShipPoint(point, ship);
            var sb = new StringBuilder();

            var expectedPrint = sb.AppendLine($"X = {point.X}  Y = {point.Y} Distance = {sp.Distance} Type - {ship.GetType().Name}").ToString();
            var battlefield = this.CreateBattlefield(5);
            battlefield.AddShip(point, point, ship);
            // Act
            var result = battlefield.Print();

            // Assert
            result.Should().Be(expectedPrint);
        }

        [Fact]
        public void Print_WhenShipDoNotExists_ShoulReturnBFState()
        {
            // Arrange

            var battlefield = this.CreateBattlefield(5);

            // Act
            var result = battlefield.Print();

            // Assert
            result.Should().BeNullOrEmpty();
        }

        [Fact]
        public void DeleteShip_WhenShipDeleted_ShouldReturnTrue()
        {
            // Arrange
            var ship = new Military(1);
            var battlefield = this.CreateBattlefield(5);
            battlefield.AddShip(new Point(0, 0), ship);
            var idShip = ship.Id;
            // Act
            var result = battlefield.DeleteShip(idShip);

            // Assert
            result.Should().BeTrue();
            battlefield.Ships.Should().BeEmpty();
        }

        [Fact]
        public void DeleteShip_WhenShipDeleted_ShouldReturnFalse()
        {
            // Arrange
            var ship = new Military(1);
            var battlefield = this.CreateBattlefield(5);
            battlefield.AddShip(new Point(0, 0), ship);
            var idShip = new Guid();

            // Act
            var result = battlefield.DeleteShip(idShip);

            // Assert
            result.Should().BeFalse();
            battlefield.Ships.Should().NotBeEmpty();
        }

        //TODO нет ID

        //TODO позитивный тест для индексатора - var expShip = battlefield[Quadrant.I, startPosition.XAbs, startPosition.YAbs];

        [Fact]
        public void AddShip_WhenTheShipExists_ExpectedСoordinatesShip()
        {
            // Arrange
            var battlefield = this.CreateBattlefield(11);
            Point startPosition = new Point(0, 0);

            Ship ship = new Military(20);

            // Act
            battlefield.AddShip(startPosition, ship);

            // Assert
            var expShip = battlefield[Quadrant.I, startPosition.XAbs, startPosition.YAbs];

            expShip.Should().NotBeNull();
        }

        //TODO негативный тест для индексатора  - "Корабля нет"
    }
}