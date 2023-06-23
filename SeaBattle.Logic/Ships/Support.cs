using SeaBattle.Logic.Interfaces;

namespace SeaBattle.Logic.Ships;

public class Support : Ship, IRepairable
{
    public Support(int maxSpeed, Guid id) : base(maxSpeed, id)
    {
        Type = ShipType.Support;
    }

    public override void Move()
    {
        Console.WriteLine("поддержано двигаюсь");
    }

    public void Repair()
    {
        Console.WriteLine("я ремонтирую");
    }
}