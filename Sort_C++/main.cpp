// Sort_C++.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "sort.h"

void CreateRandom(int* List, int iElements, int iMax)
{

}

int main()
{
	const int iElements = 1000000;
	const int iMax = 10000;
	int List[iElements];

	CreateRandom(List, iElements, iMax);
	Sort::Sort(List, iElements);

    return 0;
}

