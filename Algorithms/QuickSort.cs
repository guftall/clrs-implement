using System;
using System.Collections.Generic;

namespace Algorithms.Sort
{
    public class QuickSort : ISort
    {
        
        private static Random r = new Random(DateTime.Now.Millisecond);

        public static void DefaultQuickSort(List<int> array, int p, int r)
        {
            if (p >= r) return;
            int q = Partition(array, p, r);
            DefaultQuickSort(array, p, q - 1);
            DefaultQuickSort(array, q + 1, r);

        }

        private static int Partition(IList<int> array, int p, int r)
        {
            int x = array[r];
            int i = p-1;
            
            for (int j=p; j < r; j++)
            {
                if (array[j] >= x) continue;
                ++i;
                Exchange(array, i, j);
            }
            
            Exchange(array, i + 1, r);
            return i + 1;
        }

        public static void RandomizedQuickSort(List<int> array, int p, int r)
        {
            
            if (p >= r) return;
            int q = RandomizedPartition(array, p, r);
            RandomizedQuickSort(array, p, q - 1);
            RandomizedQuickSort(array, q + 1, r);
        }

        private static int RandomizedPartition(List<int> array, int p, int r)
        {
            var i = QuickSort.r.Next(p, r);
            Exchange(array, i, r);
            return Partition(array, p, r);
        }

        private static void Exchange(IList<int> array, int x, int y)
        {
            int tmp = array[x];
            array[x] = array[y];
            array[y] = tmp;
        }

        public void Sort(List<int> array)
        {
            RandomizedQuickSort(array, 0, array.Count - 1);
        }
    }
}