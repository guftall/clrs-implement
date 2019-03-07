using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class CountingSort : ISort
    {

        public static void _Sort(List<int> array, int k)
        {

            var cArr = new int[k + 1];
            var bArr = new int[array.Count];
            
            // all elements in int[] is initialized to 0

            for (int j=1; j<array.Count; j++)
            {
                if (array[j] > k)
                {
                    throw new ArgumentOutOfRangeException(nameof(k), "numbers is array must be less than or equal to k");
                }
                ++cArr[array[j]];
            }

            for (int i = 1; i < k + 1; i++)
            {
                cArr[i] = cArr[i - 1] + cArr[i];
            }


            foreach (var t in array)
            {
                bArr[cArr[t]] = t;
                --cArr[t];
            }
            
            array.Clear();
            array.AddRange(bArr);
        }

        public void Sort(List<int> array)
        {
            var max = MaxOfArray(array);
            _Sort(array, max);
        }

        private static int MaxOfArray(IEnumerable<int> array)
        {
            return array.Max();
        }
    }
}