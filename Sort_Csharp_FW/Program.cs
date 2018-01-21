using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

using Sort_Csharp;

namespace Sort_Csharp_FW
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread sortThread = new Thread(SortThread);
            sortThread.Start();

            Console.ReadLine();
        }

        private static void SortThread()
        {
            const int iElements = 1000000;
            const int iMax = 10000;

            int[] List = new int[iElements];
            CreateRandomIntArray(ref List, iMax);

            Console.Beep();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Sort.ArrayMergeSort(ref List);

            stopwatch.Stop();
            Console.Beep();
            Console.WriteLine("Elapsed Time: " + stopwatch.ElapsedMilliseconds + "ms");
        }

        public static void CreateRandomIntArray(ref int[] List, int iMax)
        {
            Random random = new Random();

            for (int i = 0; i < List.Length; i++)
            {
                List[i] = random.Next(iMax);
            }
        }
    }
}
