// hex_to_csv.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <string>

using namespace std;
namespace fs = experimental::filesystem;

int main()
{
	ofstream CSV;
	ifstream HEX;
	string input;
	cin >> input;
	int lenght;
	int addres;
//	foo();
	
	HEX.open(input + ".hex");

	if (!HEX.is_open())return 0;
	CSV.open(input + ".csv");
	while (!HEX.eof())
	{
		getline(HEX, input, ':');
		if (input.length() == 0) continue;
		lenght = strtoul(input.substr(0, 2).c_str(), nullptr, 16)*2;
		addres = strtoul(input.substr(2, 4).c_str(), nullptr, 16);
		for (int index = 0; index < lenght; index+=2)
		{

			CSV << hex << addres;
			addres++;
			CSV  << ",";
			CSV << input.substr(8 + index, 2) + ",";
			CSV << " ," << endl;
		}
	}

	return 0;
}

