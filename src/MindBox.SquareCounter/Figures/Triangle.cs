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

    public bool IsTriangleRect()
    {
        double[] sidesOrdered =  [ _firstSide, _secondSide, _thirdSide ];
        Array.Sort(sidesOrdered);

        var biggestSide = sidesOrdered.Last();
        var otherSidesSum = sidesOrdered.Where(x => x != biggestSide).Sum(x => Math.Pow(x, 2));

        var biggestSidePow = Math.Pow(biggestSide, 2);

        return Math.Round(biggestSidePow - otherSidesSum) < 1e-10;
    }

    private double CountSemiPerimeter(double firstSide, double secondSide, double thirdSide)
    {
        return (firstSide + secondSide + thirdSide) / 2;
    }

    private double CountSquare(double firstSide, double secondSide, double thirdSide, double perimeter)
    {
        return Math.Sqrt(perimeter * (perimeter - firstSide) * (perimeter - secondSide) * (perimeter - thirdSide));
    }

    private double GetMax(params double[] values)
    {
        return values.Max();
    }
}
