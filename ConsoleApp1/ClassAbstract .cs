using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;

internal class ClassAbstract
{
}

internal class Player
{
    public void Fire(IWeapon weapon)
    {
        weapon.Fire();
    }

    public void CheckInfo(IHasInfo hasInfo)
    {
        hasInfo.ShowInfo();
    }

    public void Throw(IThrowingWeapon throwingWeapon)
    {
        throwingWeapon.Throw();
    }
}

internal interface IHasInfo
{
    void ShowInfo();
}

internal interface IWeapon
{
    int Damage { get; }

    void Fire();
}

internal interface IThrowingWeapon : IWeapon
{
    void Throw();
}

internal class Box : IHasInfo
{
    public void ShowInfo()
    {
        Console.WriteLine("Коробка");
    }
}

internal abstract class Weapon : IHasInfo, IWeapon //
{
    public abstract int Damage { get; }

    public abstract void Fire();

    public void ShowInfo()
    {
        Console.WriteLine($"{GetType().Name} Damage: {Damage}");
    }
}

internal class Knife : IThrowingWeapon
{
    public int Damage => 6;

    public void Fire()
    {
        Console.WriteLine($"{GetType().Name}: Хыц");
    }

    public void Throw()
    {
        Console.WriteLine($"{GetType().Name}: Фуц");
    }
}

internal class Gun : Weapon
{
    public override int Damage
    { get { return 5; } }

    public override void Fire()
    {
        Console.WriteLine("Пыщ");
    }
}

internal class LaserGun : Weapon
{
    public override int Damage
    { get { return 8; } }

    public override void Fire()
    {
        Console.WriteLine("Пиу");
    }
}

internal class Bow : Weapon
{
    public override int Damage => 3;

    public override void Fire()
    {
        Console.WriteLine("Чпунь");
    }
}