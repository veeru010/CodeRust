using System;
using System.Text;
using System.Collections.Generic;

namespace CodeRust.Math
{
  public static class FindPermutationTest
  {
    public static void Run()
    {
      Console.WriteLine("Find Permutations for 1234");
      var results = new FindPermutation().GetAll("1234");
      foreach(var result in results)
      {
        Console.WriteLine(result);
      }
    }
  }

  public class FindPermutation
  {
    public List<string> GetAll(string input)
    {
      List<string> result = new List<string>();
      if(input == null) return result;
      if(input.Length <= 1)
      {
        result.Add(input);
        return result;
      }

      Build(input.ToCharArray(),0,input.Length-1,new StringBuilder(),result);
      return result;
    }

    private void Build(char[] input, int startIdx,int endIdx,StringBuilder builder,List<string> result)
    {
      if(startIdx == endIdx)
      {
        builder.Append(input[startIdx]);
        result.Add(builder.ToString());
        builder.Length -= 1;
        return;
      }

      for(int i = startIdx; i <= endIdx; i++)
      {
        Swap(input,i,startIdx);
        builder.Append(input[startIdx]);
        Build(input,startIdx+1,endIdx,builder,result);
        builder.Length -= 1;
        Swap(input,i,startIdx);
      }
    }

    private void Swap(char[] input,int idx1,int idx2)
    {
      if(idx1 != idx2)
      {
        char temp = input[idx1];
        input[idx1] = input[idx2];
        input[idx2] = temp;
      }
    }
  }
}