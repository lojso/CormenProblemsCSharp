namespace Cormen._2_GettingStarted
{
    public static class BinarySearch
    {
        public static int Search(int[] array, int value)
        {
            var low = 0;
            var high = array.Length - 1;
            while (low <= high)
            {
                var mid = (low + high) / 2;
                
                if(value == array[mid])
                    return mid;

                if (value < array[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return -1;
        }

        public static int RSearch(int[] array, int value)
        {
            return RSortImpl(array, value, 0, array.Length - 1);
        }

        private static int RSortImpl(int[] array, int value, int low, int high)
        {
            if (low > high)
                return -1;
            
            var mid = (low + high) / 2;
            
            if (value == array[mid])
                return mid;

            if (value < array[mid])
            {
                return RSortImpl(array, value, low, mid - 1);
            }
            else
            {
                return RSortImpl(array, value, mid + 1, high);
            }
        }
    }
}