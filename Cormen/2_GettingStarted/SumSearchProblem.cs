using System;

namespace Cormen._2_GettingStarted
{
    public static class SumSearchProblem
    {
        public static bool Solve(int[] s, int x)
        {
            MergeSort.Sort(s); // lg(n)

            for (int i = 0; i < s.Length; i++)
            {
                var val = x - s[i];
                if(BinarySearch.Search(s, val) != -1)
                    return true;
            }

            return false;
        }
    }
}