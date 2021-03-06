using System;

namespace Cormen._2_GettingStarted
{
    public static class SumSearchProblem
    {
        public static bool Solve(int[] s, int x)
        {
            MergeSort.Sort(s); // lg(n)

            for (int i = 0; i < s.Length; i++) // n
            {
                var val = x - s[i];         // n
                var valIndex = BinarySearch.Search(s, val); // n * lg(n)
                if (valIndex != -1 && valIndex != i)
                    return true;
            }

            return false;
        }
    }
}