using System;
using System.Diagnostics;

namespace IT481_IvanMartinovich_Unit7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] smallA = RandArray(10);
            int[] medA = RandArray(1000);
            int[] bigA = RandArray(10000);

            Console.WriteLine("For Small Data Set:");
            ExecuteAlgorithm(smallA);

            Console.WriteLine("\nFor Medium Data Set:");
            ExecuteAlgorithm(medA);

            Console.WriteLine("\nFor Big Data Set:");
            ExecuteAlgorithm(bigA);

            Console.Read();
        }

        //Returns array of randomized integers between 0 and 100000 based on given size
        static int[] RandArray(int size)
        {
            int[] array = new int[size];
            Random r = new Random();
            for(int i = 0; i < size; i++)
            {
                array[i] = r.Next(0, 100000);
            }
            return array;
        }

        //Uses stopwatch to determine how long the algorithm took to process the given array
        static void ExecuteAlgorithm(int[] array)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            BubbleSort(array);
            sw.Stop();
            Console.WriteLine($"BubbleSort Execution Time: {sw.Elapsed.TotalMilliseconds} milliseconds");

            sw.Restart();
            QuickSort(array);
            sw.Stop();
            Console.WriteLine($"QuickSort Execution Time: {sw.Elapsed.TotalMilliseconds} milliseconds");
        }

        //https://dotnettutorials.net/lesson/bubble-sort-algorithm-in-csharp/
        static void BubbleSort(int[] intA)
        {
            int count = 0;
            for(int i = 0; i < intA.Length - 1 - i; i++)
            {
                for(int j = 0; j < intA.Length - 1 - j; j++)
                {
                    count++;
                    if(intA[j] > intA[j + 1])
                    {
                        int temp = intA[j + 1];
                        intA[j + 1] = intA[j];
                        intA[j] = temp;
                    }
                }
            }
        }

        //https://code-maze.com/csharp-quicksort-algorithm/
        static void QuickSort(int[] intA, int? leftIndex = null, int? rightIndex = null)
        {
            int left = leftIndex ?? 0;
            int right = rightIndex ?? intA.Length - 1;

            var i = left;
            var j = right;
            var pivot = intA[left];

            while(i <= j)
            {
                while(intA[i] < pivot)
                {
                    i++;
                }
                while(intA[j] > pivot)
                {
                    j--;
                }
                if(i <= j)
                {
                    int temp = intA[i];
                    intA[i] = intA[j];
                    intA[j] = temp;
                    i++;
                    j--;
                }
            }
            if(left < j)
                QuickSort(intA, left, j);
            if (i < right)
                QuickSort(intA, i, right);
        }
    }
}
