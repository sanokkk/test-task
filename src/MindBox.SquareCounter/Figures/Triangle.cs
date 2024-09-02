using MindBox.SquareCouter.Interfaces;

namespace MindBox.SquareCouter.Figures;

public sealed class Triangle : IFIgure
{
    public double Square { get; private set; }
    
    private double _firstSide;
    private double _secondSide;
    private double _thirdSide;

    public Triangle(double firstSide, double secondSide, double thirdSide)
    {
        _firstSide = firstSide;
        _secondSide = secondSide;
        _thirdSide = thirdSide;

        var semiPerimeter = CountSemiPerimeter(firstSide, secondSide, thirdSide);
        Square = CountSquare(firstSide, secondSide, thirdSide, semiPerimeter);
    }

    private double CountSemiPerimeter(double firstSide, double secondSide, double thirdSide)
    {
        return (firstSide + secondSide + thirdSide) / 2;
    }

    private double CountSquare(double firstSide, double secondSide, double thirdSide, double perimeter)
    {
        return Math.Sqrt(perimeter * (perimeter - firstSide) * (perimeter - secondSide) * (perimeter - thirdSide));
    }
}
