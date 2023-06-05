using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;

internal class ClassBase
{
}

/* base */

internal class Point2D
{
    public Point2D(int x, int y)
    {
        X = x;
        Y = y;
        Console.WriteLine("Вызван конструктор Point2D");
    }

    public int X { get; set; }
    public int Y { get; set; }

    public void Print2D()
    {
        Console.WriteLine("X:\t" + X);
        Console.WriteLine("Y:\t" + Y);
    }
}

internal class Point3D : Point2D
{
    public Point3D(int x, int y, int z) : base(x, y)
    {
        Z = z;
        Console.WriteLine("Вызван конструктор Point3D");
    }

    public int Z { get; set; }

    public void Print3D()
    {
        Print2D();
        Console.WriteLine("Z:\t" + Z);
    }
}