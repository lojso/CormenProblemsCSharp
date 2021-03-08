namespace Cormen._2_GettingStarted
{
    public static class CountInversion
    {
        public static int Count(int[] array)
        {
            return Count(array, 0, array.Length - 1);
        }

        private static int Count(int[] array, int low, int high)
        {
            if(low >= high)
                return 0;

            var pivot = (low + high) / 2;
            var left =  Count(array, low, pivot);
            var right = Count(array, pivot + 1, high);
            return CountMerge(array, low, pivot, high) + left + right;
        }

        private static int CountMerge(int[] array, int low, int pivot, int high)
        {
            var left = new int[pivot - low + 1];
            var right = new int[high - pivot];
            
            for (int i = 0; i < left.Length; i++)
            {
                left[i] = array[low + i];
            }
            
            for (int j = 0; j < right.Length; j++)
            {
                right[j] = array[pivot + j + 1];
            }

            int leftIndex = 0;
            int rightIndex = 0;
            int k = low;

            var inversions = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] <= right[rightIndex])
                {
                    array[k] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    array[k] = right[rightIndex];
                    inversions += left.Length - leftIndex;
                    rightIndex++;
                }
                k++;
            }

            while (leftIndex < left.Length)
            {
                array[k] = left[leftIndex];
                leftIndex++;
                k++;
            }
            
            while (rightIndex < right.Length)
            {
                array[k] = right[rightIndex];
                rightIndex++;
                k++;
            }

            return inversions;
        }
    }
}