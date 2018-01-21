
#include <cstdlib>
#include <ctime>
#include <iostream>
#include <chrono>
#include <string>

#include "sort.h"

using namespace std;

int iElements = 0;
int iMax = 0;
int* List;

void CreateRandom(int* List, int iElements, int iMax)
{
	srand((unsigned)time(0));

	for (int i = 0; i < iElements; i++)
	{
		List[i] = (rand() % iMax) + 1;
	}
}

int main()
{
	char cRe = ' ';
	while (cRe != 'y')
	{
		cout << "Elements: ";
		cin >> iElements;
		if (cin.fail())
		{
			cin.clear();
			cin.ignore(10000, '\n');
			continue;
		}
		cout << "Max. Number: ";
		cin >> iMax;
		if (cin.fail())
		{
			cin.clear();
			cin.ignore(10000, '\n');
			continue;
		}

		List = new int[iElements];

		CreateRandom(List, iElements, iMax);

		auto start = chrono::high_resolution_clock::now();
		Sort::MergeSort(List, iElements);
		auto finish = chrono::high_resolution_clock::now();
		chrono::duration<double> elapsed = finish - start;
		cout << "Lists: " << Sort::iExLists;
		cout << "\nMerges: " << Sort::iMerges;
		cout << "\nElapsed time: " << elapsed.count() * 1000 << " ms \n\n";
		delete List;

		cout << "Exit? (y)\n";
		cin >> cRe;
		if (cin.fail())
		{
			cin.clear();
			cin.ignore(10000, '\n');
		}
		while(getchar() != '\n')
		{ }
	}

	return 0;
}