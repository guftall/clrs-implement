using System.Collections.Generic;
using DataStructures.Heap;

namespace Algorithms.Sort
{
    public class HeapSort : ISort
    {
        public void Sort(List<int> array)
        {
            var maxHeap = MaxHeap.BuildHeap(array);

            for (int i = 0; i < array.Count; i++)
            {
                /* Notice
                 * x parameter always must be member by index 0, means root of tree
                 */
                MaxHeap.Exchange(array, 0, array.Count - i - 1);
                --maxHeap.HeapSize;
                maxHeap.Heapify(0);
            }
        }
    }
}