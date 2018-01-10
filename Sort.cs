using System;
using System.Collections.Generic;
using System.Text;

namespace HTL_Natural_Mergesort
{
    class Sort
    {
        public Sort()
        {

        }

        public void MergeSort(int[] List)
        {
            List<List<int>> Elements = new List<List<int>>();
            for(int i = 0; i < List.Length - 1; i++)
            {
                List<int> Element = new List<int>();
                do
                {
                    Element.Add(List[i]);
                } while (List[i] <= List[i + 1]);
                Elements.Add(Element);
            }
        }
    }

    abstract class SortTools<T>
    {
        public static void Swap(ref T A, ref T B)
        {
            T Buffer = A; A = B; B = Buffer;
        }
    }
}
