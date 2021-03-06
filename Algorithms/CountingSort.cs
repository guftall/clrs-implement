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
            
            // all elements in int[] is already initialized to 0

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

        public void SortBasedOnBitNumber(ref List<int> array, int bit)
        {
            var cArr = new int[2];
            var bArr = new List<int>(array.Count);
            bArr.AddRange(Enumerable.Repeat(0, array.Count));


            int cArrIndex = 1 << bit;
            for (int i = 0; i < array.Count; i++)
            {
                ++cArr[(array[i] & cArrIndex) > 0 ? 1 : 0];
            }

            cArr[1] = cArr[1] + cArr[0];
            
            for (int i = array.Count - 1; i >= 0 ; i--)
            {
                bArr[cArr[(array[i] & cArrIndex) > 0 ? 1 : 0] - 1] = array[i];
                --cArr[(array[i] & cArrIndex) > 0 ? 1 : 0];
            }

            array = bArr;
        }

        private static int MaxOfArray(IEnumerable<int> array)
        {
            return array.Max();
        }
    }
}