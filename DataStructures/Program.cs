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
            
            TestBinaryTreePrintRecursive();
        }

        static void TestBinaryTreePrintRecursive()
        {
            int i = 0;
            var t = BinaryTree.InitializeSimpleTree(4, ref i);
            BinaryTree.VisitNonRecursive(t);
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