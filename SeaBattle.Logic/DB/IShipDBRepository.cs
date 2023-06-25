using SeaBattle.Logic.Ships;

namespace SeaBattle.Logic.DB;

public interface IShipDBRepository
{
    Ship GetById(int id);

    List<Ship> GetAllShip();

    bool Create(Ship ship);

    void Update(Ship ship);

    bool Delete(Guid ship);
}