namespace Cormen._2_GettingStarted
{
    public static class InsertionSort
    {
        public static void Sort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] >= key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }
        }

        public static void RecursiveSort(int[] array, int n)
        {
            if(n <= 0)
                return;
            
            RecursiveSort(array, n - 1);
            
            int key = array[n];
            int j = n - 1;
            while (j >= 0 && array[j] >= key)
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = key;
        }
    }
}