using Xunit;
using Coursework.Determinant;
using FluentAssertions;

namespace Coursework.Tests.Determinant;

public class Generic: IClassFixture<MatrixFixture>
{
    private readonly MatrixFixture _fixture;
    private readonly IDeterminantCalculator<double> _determinantCalculator;

    public Generic(MatrixFixture fixture)
    {
        _fixture = fixture;
        _determinantCalculator = new DeterminantCalculator<double>(_fixture.Matrix, _fixture.Size);
    }

    [Fact]
    public void CalculatorSize()
    {
        _determinantCalculator.Size.Should().Be(3);
    }

    [Fact]
    public void CalculatorRows()
    {
        _determinantCalculator.Rows.Should().Be(2);
    }

    [Fact]
    public void CalculatorCols()
    {
        _determinantCalculator.Cols.Should().Be(3);
    }
}