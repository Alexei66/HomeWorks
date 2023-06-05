using SeaBattle.Logic.Interfaces;

namespace SeaBattle.Logic.Ships;

public class Mixed : Ship, IRepairable, IShootable
{
    public Mixed(int maxSpeed) : base(maxSpeed)
    {
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