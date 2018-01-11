using System;

namespace HTL_Natural_Mergesort
{
    class Program
    {
        const int iElements = 1000000;
        const int iMax = 10000;
        static void Main(string[] args)
        {
            Sort Sorting = new Sort();

            int[] List = new int[iElements];
            CreateRandomIntArray(ref List, iMax);

            Console.Beep();
            Sorting.ListedMergeSort(ref List);
            Console.Beep();

            Console.ReadLine();
        }

        public static void CreateRandomIntArray(ref int[] List, int iMax)
        {
            Random random = new Random();

            for(int i = 0; i < List.Length; i++)
            {
                List[i] = random.Next(iMax);
            }
        }
    }
}
