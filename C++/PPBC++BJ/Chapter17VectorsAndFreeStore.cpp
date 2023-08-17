/*
Here we are going to work through Chapter 17 of Principles of Programming in C++ by Bjarne Stroup
This chapter will focus on heap storage, pointers, casts and references
*/


#include <iostream>
	using std::cout;
	using std::cin;
#include <vector>
	using std::vector;


/*
Let's manually create a vector class
*/

class vector {
	int size, age0, age1, age2, age3;
}

int main () {
	vector<double> age(4);
		age[0]=0.33;
		age[1]=22.0;
		age[2]=27.2;
		age[3]=54.2;
}
