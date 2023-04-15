namespace Module8;

public class ConsoleWriter
{
    // вывод все в консоль, cw только тут
    /*
     1. В Консоль может писать только класс ConsoleWriter ... а точнее его экземпляр
        var consoleWriter = new ConsoleWriter();

        2. Никто не запрещает в другие классы передать в конструктор ConsoleWriter и использовать его уже в другом классе)
        Например:

        private ConsoleWriter _consoleWriter; //это приватное поле класса JsonFileWriteRead

        public JsonFileWriteRead(ConsoleWriter consoleWriter) //это конструктор
        {
            _consoleWriter = consoleWriter; //тут мы присвоили параметр, который передали нашему приватному свойству)
        }

        И дальше внутри JsonFile... вызывать _consoleWriter.PrintLine(); и т.д.)
    */

    public void PrintLine(string text)
    {
        Print(text + Environment.NewLine);
    }

    public void Print(string text)
    {
        Console.Write(text);
    }

    public string Read()
    {
        return Console.ReadLine();
    }
}