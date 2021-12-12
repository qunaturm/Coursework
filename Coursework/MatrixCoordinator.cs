using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    public class MatrixCoordinator
    {
        public static void BuildMinor(int[] matrix, int matrixRowSize, (int, int)[] minorSpec, ref int[] minorMatrix, int minorRowSize)
        {
            int i = 0, j = 0;
            foreach (var minor in minorSpec)
            {
                minorMatrix[j * minorRowSize + i] = matrix[minor.Item1 * matrixRowSize + minor.Item2];
                i++;
                if (i >= minorRowSize)
                {
                    i = 0;
                    j++;
                }
            }
        }
    }
}
