using SeaBattle.Logic.Ships;

namespace SeaBattle.Logic;

public class ShipPoint
{
    public ShipPoint(Point point, Ship ship)
    {
        Point = point;
        Ship = ship;
        Distance = Math.Sqrt((Point.X * Point.X) + (Point.Y * Point.Y));
    }

    public Point Point { get; set; }
    public Ship Ship { get; set; }

    public double Distance
    { get; }

    //TODO посчитать расстояние до центра
}