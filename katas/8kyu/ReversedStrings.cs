using System;
using System.Collections.Generic;

public static class Kata
{
  public static string Solution(string str) 
  {
    char[] charArr = str.ToCharArray();
    string reversed = "";
    
    for (int i = charArr.Length - 1; i >= 0; i--)
    {
      reversed += charArr[i];
    }
    
    return reversed;
  }
}
