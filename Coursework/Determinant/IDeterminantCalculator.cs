namespace Coursework.Determinant;

public interface IDeterminantCalculator<T> where T : IComparable<T>
{
    T Calculate();
    public int Size { get; }
    public int Cols { get; }
    public int Rows { get; }

    T Calculate(T[,] matrix, int size);
}
