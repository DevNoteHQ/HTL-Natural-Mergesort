
#include <iostream>

#include "sort.h"

using namespace std;

namespace Sort
{
	int iMerges = 0;
	int iExLists = 0;
	void MergeSort(int* List1, int iElements)
	{
		iMerges = 0;
		int iLists = 0;
		int* List2 = new int[iElements];
		int* CountList = new int[iElements];

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

		int* ListP[2];
		ListP[0] = &List1[0];
		ListP[1] = &List2[0];
		int iPointer = 0;

		while (iLists > 1)
		{
			for (int i = 0; i < iLists - 1; i += 2)
			{
				Merge(ListP[iPointer], ListP[(~iPointer) & 0x1], CountList[i], CountList[i + 1]);
				CountList[i / 2] = CountList[i] + CountList[i + 1];
				ListP[0] += CountList[i / 2];
				ListP[1] += CountList[i / 2];
			}
			if (iLists % 2)
			{
				for (int i = 0; i < CountList[iLists - 1]; i++)
				{
					ListP[(!iPointer) & 1][i] = ListP[iPointer][i];
				}
				CountList[iLists / 2] = CountList[iLists - 1];
			}
			ListP[0] = &List1[0];
			ListP[1] = &List2[0];
			iPointer = (!iPointer) & 0x1;
			iLists = iLists / 2 + iLists % 2;
		}

		if (iPointer == 1)
		{
			for (int i = 0; i < iElements; i++)
			{
				List1[i] = List2[i];
			}
		}
		delete CountList;
		delete List2;
	}

	void Merge(int* ListA, int* ListB, int iLengthA, int iLengthB)
	{
		iMerges++;
		int iLength = iLengthA + iLengthB;
		for (int i = 0, iA = 0, iB = iLengthA; i < iLength; i++)
		{
			if (iA >= iLengthA)
			{
				for (; i < iLength; i++, iB++)
				{
					ListB[i] = ListA[iB];
				}
				break;
			}
			if (iB >= iLength)
			{
				for (; i < iLength; i++, iA++)
				{
					ListB[i] = ListA[iA];
				}
				break;
			}
			if (ListA[iA] < ListA[iB])
			{
				ListB[i] = ListA[iA];
				iA++;
			}
			else
			{
				if (ListA[iB] < ListA[iA])
				{
					ListB[i] = ListA[iB];
					iB++;
				}
				else
				{
					ListB[i] = ListA[iA];
					i++; iA++;
					ListB[i] = ListA[iB];
					iB++;
				}
			}
		}
	}
}