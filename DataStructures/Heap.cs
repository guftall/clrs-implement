using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Heap
{

    public static class Heap
    {
        public static void HeapSort(List<int> list)
        {

            var maxHeap = MaxHeap.BuildHeap(list);

            for (int i = 0; i < list.Count; i++)
            {
                /* Notice
                 * x parameter always must be member by index 0, means root of tree
                 */
                maxHeap.exchange(list, 0, list.Count - i - 1);
                --maxHeap.HeapSize;
                maxHeap.Heapify(0);
            }
        }
    }
    
    public interface IHeap
    {
        void Heapify(int index);
    }

    public class MaxHeap : IHeap
    {
        
        public int HeapSize { set; get; }
        private readonly IList<int> Objects;

        private MaxHeap(IList<int> array)
        {
            Objects = array;
        }

        public void Heapify(int index)
        {
            while (true)
            {
                int l = Left(index);
                int r = Right(index);
                int largest = index;

                if (l < HeapSize && Objects[l] > Objects[largest])
                {
                    largest = l;
                }

                /* Notice
                 * `r` must compare with `largest` not `index`
                 * 
                 */
                if (r < HeapSize && Objects[r] > Objects[largest])
                {
                    largest = r;
                }

                if (largest == index) return;
                exchange(Objects, index, largest);
                index = largest;
            }
        }


        internal void exchange(IList<int> list, int x, int y)
        {
            var tmp = list[x];
            list[x] = list[y];
            list[y] = tmp;
        }

        public static MaxHeap BuildHeap(List<int> array)
        {
            if (array == null)
            {
                throw new ArgumentException("array can't be null");
            }
            
            var maxHeap = new MaxHeap(array);
            maxHeap.HeapSize = array.Count;

            for (int i = array.Count - 1; i >= 0; i--)
            {
                maxHeap.Heapify(i);
            }

            return maxHeap;
        }

        private static int Left(int i)
        {
            return 2 * i + 1;
        }

        private static int Right(int i)
        {
            return 2 * i + 1 + 1;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            if (Objects.Count > 0)
            {
                builder.Append(Objects[0]);
            }
            for (int i = 1; i<Objects.Count; i++)
            {
                builder.Append($", {Objects[i]}");
            }

            return builder.ToString();
        }
    }

    public class PriorityQueueObject<T>
    {
        public int Priority { set; get; }

        private T Object { get; set; }

        public static bool operator >(PriorityQueueObject<T> h1, PriorityQueueObject<T> h2)
        {
            return h1.Priority > h2.Priority;
        }
        public static bool operator <(PriorityQueueObject<T> h1, PriorityQueueObject<T> h2)
        {
            return h1.Priority < h2.Priority;
        }
    }
}