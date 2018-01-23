using System;
using System.Text;

namespace CodeRust.Math
{
  public static class FindKthPermutationTest
  {
    public static void Run()
    {
      FindKthPermutation fp = new FindKthPermutation();
      Console.WriteLine(fp.Get("1234",13));
    }
  }

  public class FindKthPermutation
  {
    public string Get(string input,int k)
    {
      if(input == null || input.Length <= 1) return input;
      int possiblePermutations = Factorial(input.Length);
      if(k > possiblePermutations) return input;
      StringBuilder result = new StringBuilder();
      Build(input,result,k);
      return result.ToString();
    }

    private void Build(string input,StringBuilder result,int k)
    {
      Console.WriteLine($"Input : {input}");
      int length = input.Length;
      if(length == 1 || k == 0)
      {
        result.Append(input);
        return;
      }

      int nbrOfCombos = Factorial(length-1);
      int idx = k/nbrOfCombos;
      int rem = k%nbrOfCombos;
      if(rem == 0)
      {
        idx = idx-1;
        rem = nbrOfCombos;
      }

      result.Append(input[idx]);
      string nextInput = input.Remove(idx,1);
      Build(nextInput,result,rem);
    }

    private int Factorial(int n)
    {
      int result = 1;
      for(int i = 2; i <= n; i++)
      {
        result *= i;
      }

      return result;
    }
  }
}