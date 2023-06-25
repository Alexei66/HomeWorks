using SeaBattle.Logic;
using SeaBattle.Logic.DB;
using SeaBattle.Logic.Ships;

namespace SeaBattle.Client;

internal class Game
{
    private static void Main(string[] args)
    {
        var battlefield = new Battlefield(15);
        //Console.WriteLine(battlefield.Print());

        //var points1 = battlefield.GetPoints(new Point(-2, 0), new Point(2, 0));   // 5 точек
        //var points2 = battlefield.GetPoints(new Point(-2, 0), new Point(-2, 0));
        //var points3 = battlefield.GetPoints(new Point(0, 0), new Point(-2, -2));
        //var points4 = battlefield.GetPoints(new Point(0, 2), new Point(0, -2)); //5 точка

        //Console.WriteLine(sh == sh2); //t
        //Console.WriteLine(sh.Equals(sh2)); //t
        //Console.WriteLine(sh.GetHashCode() == sh2.GetHashCode()); //t

        var connectionString = "Data Source=(localdb)\\MSSQLLocalDb;Initial Catalog=SeaBattle;Integrated Security=True"; //Initial Catalog=ShipDB; User=shipAdmin;Password=shipAdmin

        var sdb = new SqlShipRepository(connectionString);

        var shipList = new List<Ship>
        {
            new Military(20,Guid.NewGuid())
            {
                Length=1
            },
            new Support(100,Guid.NewGuid())
            {
                Length=10
            },
            new Mixed(10,Guid.NewGuid())
            {
                Length=16
            },
        };
        //sdb.Create(new Mixed(66, Guid.NewGuid())
        //{
        //    Length = 10
        //});

        sdb.MultipleInsert(shipList);
        //var shipMilitary = sdb.GetById(1);
        //var shipMixed = sdb.GetById(2);
        //var shipSupport = sdb.GetById(3);

        var list = sdb.GetAllShip();

        //try
        //{
        //    battlefield.AddShip(new Point(0, 0), new Point(2, 0), sh);
        //    battlefield.AddShip(new Point(-1, -1), new Point(1, -1), sh3);
        //    battlefield.AddShip(new Point(0, 2), new Point(2, 2), sh2);
        //    battlefield.AddShip(new Point(0, 4), new Point(2, 4), sh1);
        //    //battlefield.Sort();
        //    Console.WriteLine(battlefield.Print());
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}

        //var test = battlefield[Quadrant.IV, 1, 1];
        //Console.WriteLine(test.ToString());
        //var points = new Point[]
        //{
        //    new Point(1,1),
        //    new Point(-1,1),
        //    new Point(-1,-1),
        //    new Point(1,-1),
        //    new Point(0,1),
        //    new Point(-1,0),
        //    new Point(0,-1),
        //    new Point(1,0),
        //    new Point(0,0),
        //};
        //foreach (var point in points)
        //{
        //    Console.WriteLine(point.Print());
        //}

        //var mil = new Military();
        //mil.Shoot();
        //mil.Move();
        //var rep = new Support();
        //rep.Repair();
        //var mix = new Mixed();
        //mix.Move();
    }
}