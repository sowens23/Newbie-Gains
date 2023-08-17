#include <iostream>
#include "Date.h"


int main() {

  Date d{1984,01,29};

  std::cout << d.year << "-"
	    << d.month << "-"
	    << d.day << std::endl;
  
  return 0;
}
