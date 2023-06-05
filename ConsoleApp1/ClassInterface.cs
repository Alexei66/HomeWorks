using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;

internal class ClassInterface
{
}

internal interface IDataProvider
{
    string GetData();
}

internal interface IDataProcessor
{
    void ProcessData(IDataProvider dataProvider);
}

internal class ConsoleDataProcessor : IDataProcessor
{
    public void ProcessData(IDataProvider dataProvider)
    {
        Console.WriteLine(dataProvider.GetData());
    }
}

internal class DbDataProvider : IDataProvider
{
    public string GetData()
    {
        return "Данные из ДБ";
    }
}

internal class FileDataProvider : IDataProvider
{
    public string GetData()
    {
        return "Данные из файла";
    }
}

internal class APIDataProvider : IDataProvider
{
    public string GetData()
    {
        return "Данные из API";
    }
}