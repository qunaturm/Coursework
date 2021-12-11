using System.Linq;
using Xunit;
using FluentAssertions;

namespace Coursework.Tests.Combinatorics;
public class CombinationsTest
{
    [Fact]
    public void CombinationsN4K3()
    {
        var range = 4; // 0, 1, 2, 3
        var size = 3;

        var combinations = Coursework.Combinatorics.CombinationsCaclucator.Combinations(range, size).Select(u => u.ToArray()).ToArray();


        var expected = new int[][] { new int[] { 0, 1, 2 }, new int[] { 0, 1, 3 }, new int[] { 0, 2, 3 }, new int[] { 1, 3, 2 } };
        combinations.Should().BeEquivalentTo(expected);
    }
}