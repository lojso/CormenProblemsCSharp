namespace Cormen._2_GettingStarted
{
    public static class MergeSort
    {
        public static void Sort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort(int[] array, int low, int high)
        {
            if(low >= high)
                return;

            var pivot = (low + high) / 2;
            Sort(array, low, pivot);
            Sort(array, pivot + 1, high);
            Merge(array, low, pivot, high);
        }

        private static void Merge(int[] array, int low, int pivot, int high)
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
        }
    }
}