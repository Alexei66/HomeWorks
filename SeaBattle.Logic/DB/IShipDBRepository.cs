using SeaBattle.Logic.Ships;

namespace SeaBattle.Logic.DB;

public interface IShipDBRepository
{
    Ship GetById(int id);

    List<Ship> GetAllShips();

    bool Create(Ship ship);

    bool Update(Ship ship, int id);

    bool Delete(Guid ship);
}