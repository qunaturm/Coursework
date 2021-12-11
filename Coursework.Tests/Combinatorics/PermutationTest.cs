using System.Linq;
using Xunit;
using FluentAssertions;
using Coursework.Combinatorics;

namespace Coursework.Tests.Combinatorics;

public class PermutationTest
{
    [Fact]
    public void PermutatuinFor4Element()
    {
        var range = Enumerable.Range(0, 3).ToArray().GetPermutations().ToList();

        var expected = new int[][] { new int[] { 0, 1, 2 }, new int[] { 0, 2, 1 }, new int[] { 1, 0, 2 }, new int[] { 1, 2, 0 }, new int[] { 2, 1, 0 }, new int[] { 2, 0, 1 } };
        range.Should().BeEquivalentTo(expected);
    }
}