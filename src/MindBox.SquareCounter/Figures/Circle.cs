using MindBox.SquareCouter.Interfaces;

namespace MindBox.SquareCouter.Figures;

public sealed class Circle : FigureBase
{
    internal double Square { get; private set; }

    public Circle(double raduis)
    {
        Square = 2 * Math.PI * raduis;
    }
}
