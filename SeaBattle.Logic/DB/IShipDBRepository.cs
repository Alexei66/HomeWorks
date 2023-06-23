using SeaBattle.Logic.Ships;

namespace SeaBattle.Logic.DB;

internal interface IShipDBRepository
{
    Ship GetById(int id);

    void Save(Ship ship);

    void Create(Ship ship);

    void Update(Ship ship);

    void Delete(Guid ship);
}