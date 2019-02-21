using System;
using System.Collections.Generic;
using Algorithms.Sort;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = GetHugeTestArray();
            QuickSort.RandomizedQuickSort(arr, 0, arr.Count - 1);

            Console.WriteLine($"{DateTime.Now.ToString()} Start sorting...");

//            QuickSort.DefaultQuickSort(arr, 0, arr.Count - 1); // Take too long to complete
            QuickSort.RandomizedQuickSort(arr, 0, arr.Count - 1);
            Console.WriteLine($"{DateTime.Now.ToString()} Finished");
            Console.WriteLine($"Insure: {InsureSort(arr)}");
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
            HeapSort.Sort(arr);
            PrintList(arr);
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
        
        public static List<int> GetHugeTestArray()
        {
            
            var arr = new List<int>();

            var r = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 10_000_000; i++)
            {
                arr.Add(r.Next(0, 10_000_000));
            }
            
            arr.Add(2);
            arr.Add(4);
            arr.Add(28);
            arr.Add(1);
            arr.Add(12);
            arr.Add(5);
            return arr;
        }

        public static void PrintList(List<int> arr)
        {
            
            arr.ForEach(i =>
            {
                Console.Write(i + ", ");
            });
        }

        public static bool InsureSort(List<int> array)
        {
            for (int i = 0; i < array.Count - 1; i++)
            {
                if (array[i] > array[i + 1])
                    return false;
            }

            return true;
        }
    }
}