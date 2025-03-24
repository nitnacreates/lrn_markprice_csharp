namespace Packt.Shared;

public struct DisplacementVector
{
    public int X { get; set; }
    public int Y { get; set; }

    public DisplacementVector(int initialx, int initialy)
    {
        X = initialx;
        Y = initialy;
    }

    public static DisplacementVector operator +(DisplacementVector vector1, DisplacementVector vector2)
    {
        return new(
            vector1.X + vector2.X,
            vector1.Y + vector2.Y
        );
    }
}
