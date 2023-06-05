using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;

internal class Interface2
{
}

// ЯВНАЯ РЕАЛИЗАЦИЯ интерфейса
internal interface IFirstInterface
{
    void Action();
}

internal interface ISecondInterface
{
    void Action();
}

internal class MyClass : IFirstInterface, ISecondInterface
{
    public void Action()
    {
        Console.WriteLine("MyClass Action");
    }
}

internal class MyOtherClass : IFirstInterface, ISecondInterface
{
    void IFirstInterface.Action()
    {
        Console.WriteLine("MyOtherClass IFirstInterface.Action");
    }

    void ISecondInterface.Action()
    {
        Console.WriteLine("MyOtherClass ISecondInterface.Action");
    }
}