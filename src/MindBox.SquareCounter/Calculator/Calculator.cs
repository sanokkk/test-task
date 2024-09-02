using MindBox.SquareCouter.Figures;
using MindBox.SquareCouter.Interfaces;

namespace MindBox.SquareCouter.Calculator;

public sealed class Calculator
{
    public double GetSquare(FigureBase figureBase) => figureBase.Square;

    public double GetSquare(params double[] values)
    {
        FigureBase figure;
        
        switch (values.Length)
        {
            case 1:
                figure = new Circle(values.First());
                break;
            case 3:
                figure = new Triangle(values[0], values[1], values[2]);
                break;
            default:
                throw new InvalidOperationException("Нет заданного типа фигуры");
        }

        return figure.Square;
    }

}