using SeaBattle.Logic.Ships;
using System.Text;

namespace SeaBattle.Logic;

public class Battlefield
{
    public Battlefield(int size)
    {
        if (size % 2 != 0)  // size % 2 == 0
        {
            Initialization(size); // size+1
        }
        else throw new Exception("четное число");
    }

    public Dictionary<Point, ShipPoint> Points { get; set; }

    public List<Ship> Ships
    {
        get => Points.Where(x => x.Value.Ship != null)
            .Select(x => x.Value.Ship)
            .Distinct()
            .ToList();
    }

    public void AddShip(Point startPosition, Point finishPosition, Ship ship)
    {
        var result = ValidatePoints(startPosition, finishPosition);
        if (!result.IsSuccess)
        {
            throw new Exception(result.Message);
        }

        var shipPoints = GetPoints(startPosition, finishPosition);

        ship.Length = shipPoints.Length;

        foreach (var point in shipPoints)
        {
            Points[point].Ship = ship;
        }
    }

    public void AddShip(Point startPosition, Ship ship)
    {
        AddShip(startPosition, startPosition, ship);
    }

    //возвращаемый_тип this[Тип параметр1, ...]
    //{
    //    get { ... }
    //    set { ... }
    //}
    public Ship this[Quadrant quadrant, int x, int y]
    {
        get
        {
            var point = Points.Keys.FirstOrDefault(p => p.XAbs == x && p.YAbs == y && p.Quadrant.HasFlag(quadrant)); //1, найти точку по Quadrant quadrant, int x, int y

            return Points[point].Ship ?? throw new Exception("Корабля нет");  //2 найти значение в словаре по найденной точке
        }
    }

    public bool DeleteShip(Guid shipId)
    {
        //Points.Where(s => s.Value.Ship != null && s.Value.Ship.Id == shipId).ToList().ForEach(x => x.Value.Ship = null);

        var ships = Points.Where(s => s.Value.Ship != null && s.Value.Ship.Id == shipId);

        if (!ships.Any())
        {
            return false;
        }

        ships.ToList().ForEach(x => x.Value.Ship = null);

        return true;

        //вызываешь Where и проверяешь, если там хоть что-то ...
        //Если пусто -кидаешь исключение или возвращаешь false(что лучше)
        //Если не пусто - удаляешь корабль

        //Points.Where(s => s.Value.Ship != null && s.Value.Ship.Id == shipId).ToList().ForEach(x => x.Value.Ship = null);
        //return true;
        //Points.Where(s => s.Value.Ship != null && s.Value.Ship.Id != shipId).ToList();
    }

    public string Print()
    {
        var sb = new StringBuilder();

        List<ShipPoint> sortedShipPoints = Sort();

        foreach (var ship in sortedShipPoints)
        {
            sb.AppendLine(ship.Print());
        }

        return sb.ToString();
    }

    //TODO посмотреть про метод расширения

    private List<ShipPoint> Sort()
    {
        return Points.Where(x => x.Value.Ship != null)
            .OrderBy(x => x.Value.Distance)
            .Select(x => x.Value)
            .DistinctBy(x => x.Ship)
            .ToList();
    }

    private void Initialization(int pointSize)
    {
        //  Dictionary<TKey,TValue>
        //Точки - это ключ...
        //А возвращаться будут ShipPoint
        //А внутри ShipPoint уже будет точка и корабль...если нет корабля - null

        Points = new Dictionary<Point, ShipPoint>();

        for (int row = 0; row < pointSize; row++)
        {
            int y = pointSize / 2 - row;

            for (int col = 0; col < pointSize; col++)
            {
                int x = -pointSize / 2 + col;
                var point = new Point(x, y);

                Points.Add(point, new ShipPoint(point, null));
            }
        }
    }

    private Point[] GetPoints(Point startPosition, Point finishPosition)
    {
        if (startPosition.X == finishPosition.X && startPosition.Y == finishPosition.Y)
        {
            return new Point[] { startPosition };
        }
        if (startPosition.Y == finishPosition.Y)
        {
            var min = Math.Min(startPosition.X, finishPosition.X);
            var count = Math.Abs(startPosition.X - finishPosition.X) + 1;

            var points = new Point[count];

            for (int i = 0; i < count; i++)
            {
                points[i] = new Point(min + i, startPosition.Y);
            }
            return points;
        }
        if (startPosition.X == finishPosition.X)
        {
            var min = Math.Min(startPosition.Y, finishPosition.Y);
            var count = Math.Abs(startPosition.Y - finishPosition.Y) + 1;

            var points = new Point[count];

            for (int i = 0; i < count; i++)
            {
                points[i] = new Point(startPosition.X, min + i);
            }
            return points;
        }
        return Array.Empty<Point>();
    }

    private Result CheckIntersection(Point[] newShipPoints)
    {
        foreach (var point in newShipPoints)
        {
            if (Points[point].Ship != null)   //проверить пустая точка или нет
            {
                return Result.Fail("Пересечение кораблей");
            }
        }
        return Result.Success();
    }

    private Result IsNotDiagonal(Point startPosition, Point finishPosition)
    {
        return startPosition.X == finishPosition.X || startPosition.Y == finishPosition.Y
            ? Result.Success()
            : Result.Fail("Диагональный корабль");
    }

    private Result IsOnField(Point startPosition, Point finishPosition)
    {
        return (Points.ContainsKey(startPosition) && Points.ContainsKey(finishPosition))
            ? Result.Success()  //ContainsKey(K key): проверяет наличие элемента с определенным ключом и возвращает true при его наличии в словаре
            : Result.Fail("За пределами поля");
    }

    private Result ValidatePoints(Point startPosition, Point finishPosition)
    {
        var result = IsOnField(startPosition, finishPosition);
        if (!result.IsSuccess)
        {
            return Result.Fail(result.Message);
        }
        result = IsNotDiagonal(startPosition, finishPosition);
        if (!result.IsSuccess)
        {
            return Result.Fail(result.Message);
        }
        result = CheckIntersection(GetPoints(startPosition, finishPosition));
        if (!result.IsSuccess)
        {
            return Result.Fail(result.Message);
        }
        return Result.Success();
    }
}