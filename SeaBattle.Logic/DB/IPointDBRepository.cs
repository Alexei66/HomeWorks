namespace SeaBattle.Logic.DB;

public interface IPointDBRepository
{
    Point? GetPoint(Point point);

    List<Point> GetAllPoints();

    bool Create(Point point);

    bool Delete(Point point);
}