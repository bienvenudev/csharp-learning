using System;

public static class Kata
{
  public static int CountSheeps(bool[] sheeps)
  {
    int countPresent = 0;
    
    foreach(bool sheep in sheeps) {
      if (sheep) countPresent++;
    }
    
    return countPresent;
  }
}
