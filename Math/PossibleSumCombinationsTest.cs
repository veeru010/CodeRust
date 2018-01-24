using System;
using System.Text;
using System.Collections.Generic;

namespace CodeRust.Math
{
    public static class PossibleSumCombinationsTest
    {
        public static void Run()
        {
            PossibleSumCombinations ps = new PossibleSumCombinations();
            var results = ps.GetList(5);
            foreach(var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }

    public class PossibleSumCombinations
    {
        public List<string> GetList(int target)
        {
            List<string> result = new List<string>();
            if(target <= 1)
            {
                result.Add(target.ToString());
                return result;
            }

            for(int i = 1; i < target; i++)
            {
                List<int> currentResult = new List<int>();
                currentResult.Add(i);
                Build(target,i,i,currentResult,result);
            }
            
            return result;
        }

        private void Build(int target,int currentTarget,int start,List<int> currentResult,List<string> result)
        {
            if(currentTarget == target)
            {                              
                result.Add(string.Join(",",currentResult));              
                return;
            }

            for(int i = start; i <= target - currentTarget; i++)
            {
                currentResult.Add(i);
                Build(target,currentTarget+i,i,currentResult,result);                               
                currentResult.RemoveAt(currentResult.Count - 1);
            }
        }
    }
}