namespace SeaBattle.Logic.DB;

public interface IPointDBRepository
{
    Point? GetPoint(Point point);

    List<Point> GetAllPoints();

    bool Create(Point point);

    void CreatePoints(IEnumerable<Point> point);

    bool Delete(Point point);
}