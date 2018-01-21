
#ifndef SORT_H
#define SORT_H

namespace Sort
{
	extern int iMerges;
	extern int iExLists;
	void MergeSort(int* List, int Elements);
	void Merge(int* iList1, int* iList2, int iLengthA, int iLengthB);
}

#endif