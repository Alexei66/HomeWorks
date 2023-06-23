using SeaBattle.Logic.Interfaces;

namespace SeaBattle.Logic.Ships;

public class Military : Ship, IShootable
{
    public Military(int maxSpeed, Guid id) : base(maxSpeed, id)
    {
        Type = ShipType.Military;
    }

    public override void Move()
    {
        Console.WriteLine("Военный движ");
    }

    public void Shoot()
    {
        Console.WriteLine("я стреляю");
    }
}