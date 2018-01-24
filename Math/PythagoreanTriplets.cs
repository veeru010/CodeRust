using System;
using System.Collections.Generic;

namespace CodeRust.Math
{
    public static class PythagoreanTripletsTest
    {
        public static void Run()
        {
            int[] source = {4,16,1,2,3,5,6,8,25,10};
            Console.WriteLine($"Input : {string.Join(",",source)}");
            PythagoreanTriplet pt = new PythagoreanTriplet();
            var results = pt.Find(source);
            foreach(var result in results)
            {
                Console.WriteLine($"Item1 : {result.Item1} , Item2 : {result.Item2}, Item3 : {result.Item3}");
            }
        }
    }

    public class PythagoreanTriplet
    {
        public List<Tuple<int,int,int>> Find(int[] source)
        {
            List<Tuple<int,int,int>> triplets = new List<Tuple<int, int, int>>();
            Array.Sort(source);
            for(int i = 2; i < source.Length; i++)
            {
                TwoSum(source,i,triplets);
            }

            return triplets;
        }

        public void TwoSum(int[] source,int targetIdx,List<Tuple<int,int,int>> triplets)
        {
            long target = source[targetIdx]*source[targetIdx];
            int startIdx = 0;            
            int endIdx = targetIdx - 1;

            while(startIdx < endIdx)
            {
                if(startIdx == targetIdx)
                {
                    startIdx++;
                    continue;
                }

                if(endIdx == targetIdx)
                {
                    endIdx--;
                    continue;
                }

                long result = source[startIdx]*source[startIdx] + source[endIdx]*source[endIdx];
                if(result == target)
                {
                    triplets.Add(new Tuple<int,int,int>(source[startIdx],source[endIdx],source[targetIdx]));
                    startIdx++;
                    endIdx--;
                }
                else if(result < target)
                {
                    startIdx++;
                }
                else
                {
                    endIdx--;
                }
            }
            
        }
    }
}