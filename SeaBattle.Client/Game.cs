using SeaBattle.Logic;
using SeaBattle.Logic.Ships;

namespace SeaBattle.Client;

internal class Game
{
    private static void Main(string[] args)
    {
        var battlefield = new Battlefield(3);
        //Console.WriteLine(battlefield.Print());

        //var points1 = battlefield.GetPoints(new Point(-2, 0), new Point(2, 0));   // 5 точек
        //var points2 = battlefield.GetPoints(new Point(-2, 0), new Point(-2, 0));
        //var points3 = battlefield.GetPoints(new Point(0, 0), new Point(-2, -2));
        //var points4 = battlefield.GetPoints(new Point(0, 2), new Point(0, -2)); //5 точка

        var sh = new Military(20);
        var sh3 = new Military(20);
        var sh1 = new Mixed(20);
        var sh2 = new Support(20);
        //Console.WriteLine(sh == sh2); //t
        //Console.WriteLine(sh.Equals(sh2)); //t
        //Console.WriteLine(sh.GetHashCode() == sh2.GetHashCode()); //t

        // Console.WriteLine(sp.Distance);

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

        var test = battlefield[Quadrant.IV, 1, 1];
        Console.WriteLine(test.ToString());
        var points = new Point[]
        {
            new Point(1,1),
            new Point(-1,1),
            new Point(-1,-1),
            new Point(1,-1),
            new Point(0,1),
            new Point(-1,0),
            new Point(0,-1),
            new Point(1,0),
            new Point(0,0),
        };
        foreach (var point in points)
        {
            Console.WriteLine(point.Print());
        }

        //var mil = new Military();
        //mil.Shoot();
        //mil.Move();
        //var rep = new Support();
        //rep.Repair();
        //var mix = new Mixed();
        //mix.Move();
    }
}