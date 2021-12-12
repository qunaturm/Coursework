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
		var rowsMinors = GetAxisMinors(matrixRows, minorSize);

		foreach (var _cols in colsMinors)
		{ 
			foreach (var _rows in rowsMinors)
			{
				var minor =  (from col in _cols
							  from row in _rows
							  select (row, col)).ToArray();
				yield return minor;
			}
		}
	}
}