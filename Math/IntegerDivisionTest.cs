using System;

namespace CodeRust.Math
{
  public static class IntegerDivisionTest
  {
    public static void Run()
    {
      IntegerDivision id = new IntegerDivision();
      Console.WriteLine($"17/4 = {id.GetResult(17,4)}");
    }
  }

  public class IntegerDivision
  {
    public int GetResult(int x,int y)
    {
      if(y == 0) throw new DivideByZeroException();
      if(x == y) return 1;
      if(y == 1) return x;
      if(y > x) return 0;

      int result = 0;

      while(x > y)
      {
        int shiftedY = y;
        int shift = 0;
        while(x > shiftedY)
        {
          shiftedY = shiftedY << 1;
          shift++;
        }

        result += (1 << (shift - 1));
        x = x - (shiftedY >> 1);
      }

      return result;
    }
  }
}