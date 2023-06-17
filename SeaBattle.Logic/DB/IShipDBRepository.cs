using SeaBattle.Logic.Ships;

namespace SeaBattle.Logic.DB;

internal interface IShipDBRepository
{
    Ship GetById(int id);

    void Save(Ship ship);

    void Update(Ship ship);

    void Delete(Ship ship);
}

public class ShipRepository : IShipDBRepository
{
    public Ship GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Save(Ship ship)
    {
        throw new NotImplementedException();
    }

    public void Update(Ship ship)
    {
        throw new NotImplementedException();
    }

    public void Delete(Ship ship)
    {
        throw new NotImplementedException();
    }
}