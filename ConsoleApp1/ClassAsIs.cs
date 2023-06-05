using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;

internal class ClassAsIs
{
}

internal class Point
{
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public void Print()
    {
        Console.WriteLine("X:\t" + X);
        Console.WriteLine("Y:\t" + Y);
    }

    private object obj = new Point(3, 5);

    private static void Foo(object obj)
    {
        Point point = obj as Point;
        if (point != null)
        {
            point.Print();
        }
    }

    private static void Bar(object obj)
    {
        if (obj is Point point)
        {
            point.Print();
        }
    }
}