using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using DataStructures.Heap;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            
//            TestHeapSort();
        }

        static void TestMaxHeap()
        {
            
            var arr = new List<int>();
            
            arr.Add(2);
            arr.Add(4);
            arr.Add(28);
            arr.Add(1);
            arr.Add(12);
            arr.Add(5);

            var maxHeap = MaxHeap.BuildHeap(arr);
            
            Console.WriteLine(maxHeap);
        }

        private static void TestHeapSort()
        {
            var arr = new List<int>();
            
            arr.Add(2);
            arr.Add(4);
            arr.Add(28);
            arr.Add(1);
            arr.Add(12);
            arr.Add(5);
            Heap.Heap.HeapSort(arr);
            arr.ForEach(i =>
            {
                Console.Write(i + ", ");
            });
        }
    }
}