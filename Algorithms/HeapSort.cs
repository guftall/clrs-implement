using System.Collections.Generic;
using DataStructures.Heap;

namespace Algorithms.Sort
{
    public class HeapSort
    {
        
        public static void Sort(List<int> list)
        {

            var maxHeap = MaxHeap.BuildHeap(list);

            for (int i = 0; i < list.Count; i++)
            {
                /* Notice
                 * x parameter always must be member by index 0, means root of tree
                 */
                MaxHeap.Exchange(list, 0, list.Count - i - 1);
                --maxHeap.HeapSize;
                maxHeap.Heapify(0);
            }
        }
    }
}