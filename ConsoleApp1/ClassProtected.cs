using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;

internal class ClassProtected
{
}

internal class A
{
    public int publicFiled;

    private int privateFiled;

    protected int protectedFiled;

    public A()
    {
        Console.WriteLine(publicFiled);
        Console.WriteLine(privateFiled);
        Console.WriteLine(protectedFiled);
    }

    public void Foo()
    {
        Console.WriteLine(publicFiled);
        Console.WriteLine(privateFiled);
        Console.WriteLine(protectedFiled);
    }
}

internal class B : A
{
    public B()
    {
        Console.WriteLine(publicFiled);
        //Console.WriteLine(privateFiled);
        Console.WriteLine(protectedFiled);
    }
}