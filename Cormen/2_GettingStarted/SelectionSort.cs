namespace Cormen._2_GettingStarted
{
    public static class SelectionSort
    {
        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                var minValueIndex = i;
                
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[minValueIndex] > array[j])
                        minValueIndex = j;
                }

                var temp = array[minValueIndex];
                array[minValueIndex] = array[i];
                array[i] = temp;
            }
        }
    }
}