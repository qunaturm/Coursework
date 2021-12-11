namespace Coursework.Determinant;
public class DeterminantCalculator<T> : IDeterminantCalculator<T>  where T : IComparable<T>
{
    private readonly T[,] _matrix;
    private readonly int _size;
    private readonly int _cols;
    private readonly int _rows;
    public DeterminantCalculator(T[,] matrix, int size)
    {
        _matrix = matrix;

        _size = 3;
        _rows = _matrix.Length / _size;
        _cols = _size;
    }

    public int Size => _size;
    public int Cols => _cols;
    public int Rows => _rows;

    public T Calculate()
    {
        if (Cols != Rows)
            throw new ArgumentException($"This matrix is not suitable for calculating the determinant: rows={this.Rows} cols={this.Cols}");
        throw new NotImplementedException();
    }

    public T Calculate(T[,] matrix, int size)
    {
        throw new NotImplementedException();
    }
}
