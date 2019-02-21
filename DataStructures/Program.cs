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

    }
}