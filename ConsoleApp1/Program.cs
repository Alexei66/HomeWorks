namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //base
            Point3D point3D = new Point3D(3, 6, 9);
            point3D.Print3D();

            //protected
            A a = new A();
            Console.WriteLine(a.publicFiled);
            //Console.WriteLine(a.privateFiled);
            //Console.WriteLine(a.protectedFiled);

            B b = new B();
            Console.WriteLine(b.publicFiled);
            //Console.WriteLine(b.privateFiled);
            //Console.WriteLine(b.protectedFiled);

            b.Foo();

            //virtual.  override - переопределяет

            Person person = new Person();
            person.Drive(new SportCar());

            //Abstract

            Player player = new Player();
            IWeapon[] inventory =
                {
                new Gun(),
                new LaserGun(),
                new Bow() ,
                new Knife(),
                };

            foreach (var item in inventory)
            {
                player.Fire(item);
                Console.WriteLine();
            }
            //Интерфейсы и полиморфизм
            player.CheckInfo(new Box());

            player.Throw(new Knife());

            IDataProcessor dataProcessor = new ConsoleDataProcessor();
            dataProcessor.ProcessData(new DbDataProvider());
            dataProcessor.ProcessData(new FileDataProvider());
            dataProcessor.ProcessData(new APIDataProvider());

            // ЯВНАЯ РЕАЛИЗАЦИЯ интерфейса

            static void Foo(IFirstInterface firstInterface)
            {
                firstInterface.Action();
            }
            static void Baa(ISecondInterface secondInterface)
            {
                secondInterface.Action();
            }

            MyClass myClass = new MyClass();
            Foo(myClass);
            Baa(myClass);

            MyOtherClass myOtherClass = new MyOtherClass();
            Foo(myOtherClass);
            Baa(myOtherClass);

            /* ТАК не исполузоуют
             *
            IFirstInterface firstInterface = myOtherClass;
            firstInterface.Action();

            НИЖЕ 2 примерa как можно */

            ((IFirstInterface)myOtherClass).Action();
            ((ISecondInterface)myOtherClass).Action();

            if (myOtherClass is IFirstInterface firstInterface)
            {
                firstInterface.Action();
            }
        }
    }
}