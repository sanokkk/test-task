using MindBox.SquareCouter.Interfaces;

namespace MindBox.SquareCouter.Figures;

public sealed class Circle : FigureBase
{
    public Circle(double raduis)
    {
        Square = Constants.Pi * Math.Pow(raduis, 2);
    }
}
