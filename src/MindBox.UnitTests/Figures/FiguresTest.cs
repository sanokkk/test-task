using System.Collections;
using MindBox.SquareCouter.Calculator;
using MindBox.SquareCouter.Figures;
using MindBox.SquareCouter.Interfaces;

namespace MindBox.UnitTests.Figures;

[TestFixture]
public sealed class FiguresTest
{
    private static IEnumerable CorrectSquareTestCases
    {
        get
        {
            yield return new TestCaseData(new Circle(10), 314);
            yield return new TestCaseData(new Triangle(3, 4, 5), 6);
            yield return new TestCaseData(new Triangle(5, 15, 11), 19.136);
        }
    }
    
    private static IEnumerable CorrectSquareWithoutFigureTypeTestCases
    {
        get
        {
            yield return new TestCaseData(new Circle(10), 314);
            yield return new TestCaseData(new Triangle(3, 4, 5), 6);
            yield return new TestCaseData(new Triangle(5, 15, 11), 19.136);
        }
    }
    
    private static IEnumerable IsTriangleRectTestCases
    {
        get
        {
            yield return new TestCaseData(new Triangle(1, 2, 4), false);
            yield return new TestCaseData(new Triangle(3, 4, 5), true);
        }
    }

    [Test]
    [TestCaseSource(nameof(CorrectSquareTestCases))]
    public void GetSquare_ShouldReturnCorrectResult(FigureBase figure, double figureSquare)
    {
        //Arrange
        var calculator = new Calculator();
        
        //Act
        var square = calculator.GetSquare(figure);
        
        //Assert
        Assert.AreEqual(square, figureSquare, 1e-10);
    }

    [Test]
    [TestCase(314, 10)]
    [TestCase(19.136, 5, 15, 11)]
    [TestCase(6, 3, 4, 5)]
    public void GetSquareWithoutFigureType_ShouldReturnCorrectResult(double expected, params double[] sides)
    {
        //Arrange
        var calculator = new Calculator();
        
        //Act
        var square = calculator.GetSquare(sides);
        
        //Assert
        Assert.AreEqual(expected, square, 1e-10);
    }

    [Test]
    public void GetSquare_WithIncorrectNumberOfParams_MustThrow()
    {
        //Arrange
        var calculator = new Calculator();
        
        //Assert
        // Calculator now doesnt support figures with 4 sides
        Assert.Throws<InvalidOperationException>(() => calculator.GetSquare(1, 2, 3, 4));
    }
    
    [Test]
    [TestCaseSource(nameof(IsTriangleRectTestCases))]
    public void IsTriangleRect_CorrectDefineRectRtiangle_MustThrow(Triangle triangle, bool isRectExpected)
    {
        //Act
        var isTriangleRect = triangle.IsTriangleRect();
        
        //Assert
        Assert.AreEqual(isRectExpected, isTriangleRect);
    }
}
