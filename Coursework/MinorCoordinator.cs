using Coursework.Combinatorics;

namespace Coursework;

public static class MinorCoordinator
{
	public static IEnumerable<int[]> GetAxisMinors(int range, int size)
	{
		foreach (var combination in CombinationsCaclucator.Combinations(range, size))
		{
			foreach (var permutation in combination.GetPermutations())
			{
				yield return permutation;
			}
		}
	}

	public static IEnumerable<(int, int)[]> GetMinors(int matrixRows, int matrixColumns, int minorSize)
	{
		var colsMinors = GetAxisMinors(matrixColumns, minorSize);
		var rowsMinors = CombinationsCaclucator.Combinations(matrixRows, minorSize);

		foreach (var _cols in colsMinors)
		{ 
			foreach (var _rows in rowsMinors)
			{
				var minor = ( from row in _rows
							  from col in _cols
							  select (row, col)).ToArray();
				yield return minor;
			}
		}
	}
}