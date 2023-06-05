using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;

internal class ClassVirtualOverride
{
}

internal class Car
{
    protected virtual void StartEngine()
    {
        Console.WriteLine("Двигатель запущен");
    }

    public virtual void Drivr()
    {
        StartEngine();
        Console.WriteLine("Машина. еду!");
    }
}

internal class SportCar : Car
{
    protected override void StartEngine()
    {
        Console.WriteLine("рон дон дон");
    }

    public override void Drivr()
    {
        StartEngine();
        Console.WriteLine("Еду очень быстро");
    }
}

internal class Person
{
    public void Drive(Car car)
    {
        car.Drivr();
    }
}