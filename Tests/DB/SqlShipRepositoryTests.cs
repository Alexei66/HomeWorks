using SeaBattle.Logic.DB;
using SeaBattle.Logic.Ships;
using Moq;
using FluentAssertions;

namespace Tests.DB;

public class SqlShipRepositoryTests
{
    //[Fact]
    //public void GetById_WhenShipIdExist_ShouldReturnShip()
    //{
    //    // Arrange
    //    var sqlShipRepository = new SqlShipRepository(TODO);
    //    int id = 0;

    //    // Act
    //    var result = sqlShipRepository.GetById(
    //        id);

    //    // Assert
    //    Assert.True(false);
    //}

    //[Fact]
    //public void GetAllShip_WhenShipExist_ShouldReturnListShip()
    //{
    //    // Arrange
    //    var sqlShipRepository = new SqlShipRepository();

    //    // Act
    //    var result = sqlShipRepository.GetAllShip();

    //    // Assert
    //    Assert.True(false);
    //}

    //[Fact]
    //public void Update_StateUnderTest_ExpectedBehavior()
    //{
    //    // Arrange
    //    var sqlShipRepository = new SqlShipRepository(TODO);
    //    Ship ship = null;

    //    // Act
    //    sqlShipRepository.Update(
    //        ship);

    //    // Assert
    //    Assert.True(false);
    //}

    //[Fact]
    //public void Delete_StateUnderTest_ExpectedBehavior()
    //{
    //    // Arrange
    //    var sqlShipRepository = new SqlShipRepository(TODO);
    //    Guid shipId = default(global::System.Guid);

    //    // Act
    //    var result = sqlShipRepository.Delete(
    //        shipId);

    //    // Assert
    //    Assert.True(false);
    //}

    //[Fact]
    //public void Create_WhenShipCreated_ShouldAddsShipToDatabase()
    //{
    //    var mock = new Mock<IShipDBRepository>();
    //    mock.Setup(a => a.Create(It.IsAny<Ship>())).Returns(true); //new Mixed(6, Guid.NewGuid()) { Length = 16 })

    //    // Arrange
    //    var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\desk\\testc\\SeaBattle.Logic\\DB\\Database1.mdf;Integrated Security=True";
    //    var shipRepository = new SqlShipRepository(connectionString);

    //    var ship = (new Mixed(6, Guid.NewGuid())
    //    {
    //        Length = 16
    //    });

    //    // Act
    //    var res = shipRepository.Create(ship);

    //    // Assert

    //    res.Should().BeTrue();
    //}
}