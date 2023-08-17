#include "Date.h"

Date::Date(int y, int m, int d)
{
  year = y;
  month = m;
  day = d;
}


// This wasn't in class, but it might be helpful for you
int Date::getYear()
{
  return year;
}

