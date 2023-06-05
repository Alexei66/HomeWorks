using SeaBattle.Logic.Interfaces;

namespace SeaBattle.Logic.Ships;

public class Military : Ship, IShootable
{
    public Military(int maxSpeed) : base(maxSpeed)
    {
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