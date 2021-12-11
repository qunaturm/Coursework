namespace Coursework.Tests;

public class MatrixFixture
{
    private readonly double[,] _matrix;
    private readonly int _size;
    private readonly int _cols;
    private readonly int _rows;
    public MatrixFixture()
    {
        _matrix = new double[,] { { 1, 2, 3}, 
                                  { 4, 5, 6} };

        _size = 3;
        _rows = _matrix.Length / _size;
        _cols = _size;
    }
    public double[,] Matrix => _matrix;
    public int Size => _size;
    public int Cols => _cols;
    public int Rows => _rows;
}
