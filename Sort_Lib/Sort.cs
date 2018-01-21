using System;
using System.Collections.Generic;
using System.Text;

namespace Sort_Csharp
{
    public abstract class Sort
    {
        static int iMerges = 0;
        static int iExLists = 0;

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
                List<int> Element = ListMerge(Elements[0], Elements[1]);
                Elements.RemoveRange(0, 2);
                Elements.Add(Element);
            }

            List = Elements[0].ToArray();
        }

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

        public static void ArrayMergeSort(ref int[] List1)
        {
            int iElements = List1.Length;
            iMerges = 0;
            int iLists = 0;
            int[] List2 = new int[iElements];
            int[] CountList = new int[iElements];

            CountList[0] = 1;

            for (int i = 1; i < iElements; i++)
            {
                if (List1[i] > List1[i - 1])
                {
                    CountList[iLists]++;
                }
                else
                {
                    iLists++;
                    CountList[iLists] = 1;
                }
            }
            iLists++;

            iExLists = iLists;

            int[][] ListP = new int[2][];
            ListP[0] = List1;
            ListP[1] = List2;
            int iPointer = 0;
            int iOffset = 0;

            while (iLists > 1)
            {
                iOffset = 0;
                for (int i = 0; i < iLists - 1; i += 2)
                {
                    ArrayMerge(ref ListP[iPointer], ref ListP[(~iPointer) & 0x1], CountList[i], CountList[i + 1], iOffset);
                    CountList[i / 2] = CountList[i] + CountList[i + 1];
                    iOffset += CountList[i / 2];
                }
                if ((iLists % 2) == 1)
                {
                    for (int i = 0; i < CountList[iLists - 1]; i++)
                    {
                        ListP[(~iPointer) & 1][iOffset + i] = ListP[iPointer][iOffset + i];
                    }
                    CountList[iLists / 2] = CountList[iLists - 1];
                }
                iPointer = (~iPointer) & 0x1;
                iLists = iLists / 2 + iLists % 2;
            }

            if (iPointer == 1)
            {
                for (int i = 0; i < iElements; i++)
                {
                    List1[i] = List2[i];
                }
            }
        }

        public static void ArrayMerge(ref int[] ListA, ref int[] ListB, int iLengthA, int iLengthB, int iOffset)
        {
            iMerges++;
            int iLength = iLengthA + iLengthB;
            for (int i = 0, iA = 0, iB = iLengthA; i < iLength; i++)
            {
                if (iA >= iLengthA)
                {
                    for (; i < iLength; i++, iB++)
                    {
                        ListB[iOffset + i] = ListA[iOffset + iB];
                    }
                    break;
                }
                if (iB >= iLength)
                {
                    for (; i < iLength; i++, iA++)
                    {
                        ListB[iOffset + i] = ListA[iOffset + iA];
                    }
                    break;
                }
                if (ListA[iOffset + iA] < ListA[iOffset + iB])
                {
                    ListB[iOffset + i] = ListA[iOffset + iA];
                    iA++;
                }
                else
                {
                    if (ListA[iOffset + iB] < ListA[iOffset + iA])
                    {
                        ListB[iOffset + i] = ListA[iOffset + iB];
                        iB++;
                    }
                    else
                    {
                        ListB[iOffset + i] = ListA[iOffset + iA];
                        i++; iA++;
                        ListB[iOffset + i] = ListA[iOffset + iB];
                        iB++;
                    }
                }
            }
        }
    }
}
