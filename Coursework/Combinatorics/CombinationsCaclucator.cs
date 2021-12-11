using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Combinatorics
{
    public class CombinationsCaclucator
    {
        static bool nextCombination(int[] num, int n, int k)
        {
            bool finished, changed;

            changed = finished = false;

            if (k > 0)
            {
                for (int i = k - 1; !finished && !changed; i--)
                {
                    if (num[i] < n - 1 - (k - 1) + i)
                    {
                        num[i]++;
                        if (i < k - 1)
                        {
                            for (int j = i + 1; j < k; j++)
                            {
                                num[j] = num[j - 1] + 1;
                            }
                        }
                        changed = true;
                    }
                    finished = i == 0;
                }
            }

            return changed;
        }

        public static IEnumerable<int[]> Combinations(int range, int size)
        {
            if (size <= range)
            {
                int[] numbers = new int[size];
                for (int i = 0; i < size; i++)
                {
                    numbers[i] = i;
                }

                do
                {
                    yield return numbers;
                }
                while (nextCombination(numbers, range, size));
                yield break;
            }
        }
    }
}
