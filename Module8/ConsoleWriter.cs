using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Module8
{
    internal class ConsoleWriters
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

            И дальше внутри JsonFile... вызывать _consoleWriter.Print(); и т.д.)
        */

        //public ConsoleWriters()
        //{
        //}

        //public string _consoleWriter;

        //public string ConsoleWriters
        //{ get { return _consoleWriter; } set { _consoleWriter = value; } }
    }
}