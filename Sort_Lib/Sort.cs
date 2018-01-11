using System;
using System.Collections.Generic;
using System.Text;

namespace Sort_Csharp
{
    public abstract class Sort
    {
        public static void ListMergeSort(ref int[] List)
        {
            List<List<int>> Elements = new List<List<int>>();
            for (int i = 0; i < List.Length;)
            {
                List<int> Element = new List<int>();
                Element.Add(List[i]);
                i++;
                try
                {
                    for (; (i < List.Length) && (List[i - 1] <= List[i]); i++)
                    {
                        Element.Add(List[i]);
                    }
                }
                catch
                {
                    Console.WriteLine("Oups! That didn't work!");
                }
                Elements.Add(Element);
            }



            while (Elements.Count > 1)
            {
                List<int> Element = SortTools.ListMerge(Elements[0], Elements[1]);
                Elements.RemoveRange(0, 2);
                Elements.Add(Element);
            }

            List = Elements[0].ToArray();
        }
    }

    abstract class SortTools
    {
        public static List<int> ListMerge(List<int> A, List<int> B)
        {
            int iLength = A.Count + B.Count;
            int[] Merged = new int[iLength];
            for (int i = 0, iA = 0, iB = 0; i < iLength; i++)
            {
                if (iB >= B.Count)
                {
                    for (; i < iLength; i++, iA++)
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
            List<int> MergedList = new List<int>();
            MergedList.AddRange(Merged);
            return MergedList;
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
