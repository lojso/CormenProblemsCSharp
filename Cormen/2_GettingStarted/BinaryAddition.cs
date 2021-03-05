namespace Cormen._2_GettingStarted
{
    public static class BinaryAddition
    {
        public static int[] Add(int[] A, int[] B)
        {
            int[] C = new int[A.Length + 1];
            var add = 0;
            for (int i = C.Length - 1; i >= 0 ; i--)
            {
                var j = i - 1 > 0 ? i - 1 : 0;
                var a = A[j];
                var b = B[j];
                C[i] = (a + b + add) % 2;
                add = (a + b) / 2;
            }

            return C;
        }
    }
}