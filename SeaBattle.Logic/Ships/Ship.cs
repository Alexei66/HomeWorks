namespace SeaBattle.Logic.Ships;

public abstract class Ship : IEquatable<Ship>
{
    protected Ship(int maxSpeed, Guid id)
    {
        MaxSpeed = maxSpeed;
        Id = id;
    }

    public abstract void Move();

    public bool Equals(Ship? other)
    {
        return this == other;
    }

    //{
    //    Console.WriteLine("я двигаюсь");
    //}
    public ShipType Type { get; init; }

    public int MaxSpeed { get; }
    public int Length { get; set; }
    public Guid Id { get; }

    /* Корабли считаются одинаковыми, если они относятся к одному типу, имеют одинаковую
     скорость и длину (для кораблей-отрезков). Сравнение кораблей должно осуществляться с
     помощью операций "==" и "!=", операции "> <>= <=" не должны поддерживаться.*/

    //public static возвращаемый_тип operator оператор(параметры)
    //{ }

    public static bool operator ==(Ship ship1, Ship ship2)
    {
        return ship1?.Length == ship2?.Length && ship1?.MaxSpeed == ship2?.MaxSpeed && ship1?.Id == ship2?.Id && ship1?.GetType() == ship2?.GetType();
    }

    public static bool operator !=(Ship ship1, Ship ship2)
    {
        return !(ship1 == ship2);
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Ship);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(MaxSpeed, Length, this.GetType());
    }
}

//TODO почему не IShip