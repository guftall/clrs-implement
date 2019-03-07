using System;
using System.Collections;
using System.Collections.Generic;
using Algorithms.Sort;

namespace Algorithms
{
    class Program
    {

        private static List<int> array;
        static void Main(string[] args)
        {
            var start = DateTime.Now;
            Console.WriteLine($"{start.ToString()} Start sorting...");

//            TestHeapSort();
//            TestQuickSort();
//            TestCountingSort();
            TestRadixSort();

            var end = DateTime.Now;
            Console.WriteLine($"{end.ToString()} Finished");
            Console.WriteLine($"Total time: {(end - start).Seconds}s | {(end - start).TotalMilliseconds}ms");
            InsureSort(array);
        }

        private static void TestRadixSort()
        {
            array = GetHugeTestArray(0, 1024);
            ISort radixSort = new RadixSort();
            radixSort.Sort(array);
        }

        private static void TestCountingSort()
        {
            array = GetHugeTestArray();
            ISort countingSort = new CountingSort();
            countingSort.Sort(array);
        }

        private static void TestQuickSort()
        {
            array = GetHugeTestArray();
            ISort quickSort = new QuickSort();
            quickSort.Sort(array);
        }
        
        private static void TestHeapSort()
        {
            array = GetHugeTestArray();
            
            ISort heapSort = new HeapSort();
            heapSort.Sort(array);
        }

        public static List<int> GetSimpleTestArray()
        {
            
            var arr = new List<int>();
            
            arr.Add(2);
            arr.Add(4);
            arr.Add(28);
            arr.Add(1);
            arr.Add(12);
            arr.Add(5);
            return arr;
        }
        
        public static List<int> GetHugeTestArray(int min = 0, int max = 10_000_000)
        {
            
            var arr = new List<int>();

            var r = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < max; i++)
            {
                arr.Add(r.Next(min, max));
            }
            return arr;
        }

        public static void PrintList(List<int> arr)
        {
            
            arr.ForEach(i =>
            {
                Console.Write(i + ", ");
            });
        }

        public static void InsureSort(List<int> array)
        {
            for (int i = 0; i < array.Count - 1; i++)
            {
                if (array[i] > array[i + 1])
                    throw new Exception("Array not sorted");
            }
        }
    }
}