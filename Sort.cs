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

        public void MergeSort(ref int[] List)
        {
            List<List<int>> Elements = new List<List<int>>();
            for(int i = 0, c = 0; i < List.Length;)
            {
                List<int> Element = new List<int>();
                Element.Add(List[i]);
                Console.WriteLine("Sublist " + Elements.Count + ": ");
                Console.WriteLine(Element[c]);
                i++; c++;
                try
                {
                    for (; (i < List.Length) && (List[i - 1] <= List[i]); i++, c++)
                    {
                        Element.Add(List[i]);
                        Console.WriteLine(Element[c]);
                    }
                }
                catch
                {
                    Console.WriteLine("Oups! That didn't work!");
                }
                c = 0;
                Elements.Add(Element);
            }

            List<int> RetList = new List<int>();

            for(int i = 0; i < Elements.Count; i++)
            {
                int[] Array = SortTools<int>.ListMerge(RetList, Elements[i]);
                RetList.Clear();
                RetList.AddRange(Array);
            }

            List = RetList.ToArray();

            Console.WriteLine("Sorted List:");

            for(int i = 0; i < List.Length; i++)
            {
                Console.WriteLine(List[i]);
            }
        }
    }

    abstract class SortTools<T>
    {
        public static void Swap(ref T A, ref T B)
        {
            T Buffer = A; A = B; B = Buffer;
        }

        public static int[] ListMerge(List<int> A, List<int> B)
        {
            int iLength = A.Count + B.Count;
            int[] Merged = new int[iLength];
            for (int i = 0, iA = 0, iB = 0; i < iLength; i++)
            {
                if (iB >= B.Count)
                {
                    for(; i < iLength; i++, iA++)
                    {
                        Merged[i] = A[iA];
                    }
                    break;
                }
                if (iA >= A.Count)
                {
                    for (; i < iLength; i++, iB++)
                    {
                        Merged[i] = B[iB];
                    }
                    break;
                }
                if (A[iA] < B[iB])
                {
                    Merged[i] = A[iA];
                    iA++;
                }
                else
                {
                    if(B[iB] < A[iA])
                    {
                        Merged[i] = B[iB];
                        iB++;
                    }
                    else
                    {
                        Merged[i] = A[iA];
                        i++; iA++;
                        Merged[i] = B[iB];
                        iB++;
                    }
                }
            }
            return Merged;
        }

        public static int[] ArrayMerge(int[] A, int[] B)
        {
            int iLength = A.Length + B.Length;
            int[] Merged = new int[iLength];
            for (int i = 0, iA = 0, iB = 0; i < iLength; i++)
            {
                if (iB >= B.Length)
                {
                    for (; i < iLength; i++, iA++)
                    {
                        Merged[i] = A[iA];
                    }
                    break;
                }
                if (iA >= A.Length)
                {
                    for (; i < iLength; i++, iB++)
                    {
                        Merged[i] = B[iB];
                    }
                    break;
                }
                if (A[iA] < B[iB])
                {
                    Merged[i] = A[iA];
                    iA++;
                }
                else
                {
                    if (B[iB] < A[iA])
                    {
                        Merged[i] = B[iB];
                        iB++;
                    }
                    else
                    {
                        Merged[i] = A[iA];
                        i++; iA++;
                        Merged[i] = B[iB];
                        iB++;
                    }
                }
            }
            return Merged;
        }
    }
}
