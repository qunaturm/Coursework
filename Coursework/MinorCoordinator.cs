using Coursework.Combinatorics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework;

public static class MinorCoordinator
{
	static IEnumerable<int[]> GetMinors(int range, int size)
	{
		foreach (var combination in CombinationsCaclucator.Combinations(range, size))
		{
			foreach (var permutation in combination.GetPermutations())
			{
				yield return permutation;
			}
		}
	}

}