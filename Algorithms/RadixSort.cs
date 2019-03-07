using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class RadixSort : ISort
    {

        private readonly Func<int, int, int> GetDigit = delegate(int number, int digitIndex)
        {
            while (digitIndex > 1)
            {
                number /= 10;
                --digitIndex;
            }

            return (number - number / (int) Math.Pow(10, digitIndex) * 10);
        };
        public void Sort(List<int> array)
        {
            var max = array.Max();
            var digitsCount = (int) Math.Ceiling(Math.Log10(max));
            
            _Sort(array.ToArray());
        }
        
        public static void _Sort(int[] arr)
        {
            Console.WriteLine((1 << 30) & 1 << 30);
            for (int bit = 0; bit <= 30; bit++)
            {
                var countingSort = new CountingSort();
                countingSort.SortBasedOnBitNumber(ref arr, bit);
            }
        }
    }
}