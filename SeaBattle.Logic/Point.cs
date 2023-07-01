namespace SeaBattle.Logic;

public struct Point
{
    public Point(int x, int y) : this()
    {
        X = x;
        Y = y;

        Quadrant = GetQuadrant(X, Y);
    }

    private Quadrant GetQuadrant(int x, int y)
    {
        if (x > 0 && y > 0)
        {
            return Quadrant.I;
        }
        else if (x < 0 && y > 0)
        {
            return Quadrant.II;
        }
        else if (x < 0 && y < 0)
        {
            return Quadrant.III;
        }
        else if (x > 0 && y < 0)
        {
            return Quadrant.IV;
        }
        else if (x == 0 && y == 0)
        {
            return Quadrant.I | Quadrant.II | Quadrant.III | Quadrant.IV;
        }
        else if (y == 0 && x > 0)
        {
            return Quadrant.I | Quadrant.IV;
        }
        else if (y == 0 && x < 0)
        {
            return Quadrant.II | Quadrant.III;
        }
        else if (x == 0 && y > 0)
        {
            return Quadrant.I | Quadrant.II;
        }
        else // if (x == 0 && y < 0)
        {
            return Quadrant.III | Quadrant.IV;
        }
    }

    public Quadrant Quadrant { get; }
    public int X { get; }
    public int Y { get; }

    public int XAbs { get => Math.Abs(X); }
    public int YAbs { get => Math.Abs(Y); }

    public string Print()
    {
        return $"X: {X}; Y: {Y}; Quadrant: {Quadrant}";
    }
}