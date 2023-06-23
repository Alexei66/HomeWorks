using SeaBattle.Logic.Interfaces;

namespace SeaBattle.Logic.Ships;

public class Mixed : Ship, IRepairable, IShootable
{
    public Mixed(int maxSpeed, Guid id) : base(maxSpeed, id)
    {
        Type = ShipType.Mixed;
    }

    public override void Move()
    {
        Console.WriteLine("Универсально двигаюсь");
    }

    public void Repair()
    {
        throw new NotImplementedException();
    }

    public void Shoot()
    {
        throw new NotImplementedException();
    }
}