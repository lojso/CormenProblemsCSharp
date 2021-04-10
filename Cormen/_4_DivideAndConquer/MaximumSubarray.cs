namespace Cormen._4_DivideAndConquer
{
    public static class MaximumSubarray
    {
        public static (int lowIndex, int highIndex, int sum) FindMaximumSubarray(int[] array, int low, int high)
        {
            if (low >= high)
                return (low, high, array[low]);


            var mid = (low + high) / 2;
            var (leftLow, leftHigh, leftSum) = FindMaximumSubarray(array, low, mid);
            var (rightLow, rightHigh, rightSum) = FindMaximumSubarray(array, mid+1, high);
            var (crossLow, crossHigh, crossSum) = FindMaximumCrossSubarray(array, low, mid, high);

            if (leftSum >= rightSum && leftSum >= crossSum)
                return (leftLow, leftHigh, leftSum);
            if (rightSum >= leftSum && rightSum >= crossSum)
                return (rightLow, rightHigh, rightSum);
            return (crossLow, crossHigh, crossSum);
        }

        private static (int lowIndex, int highIndex, int sum) FindMaximumCrossSubarray(int[] array, int low, int mid, int high)
        {
            var leftSum = int.MinValue;
            var sum = 0;
            var maxLeft = mid;
            for (int i = mid; i >= low; i--)
            {
                sum += array[i];
                if (sum > leftSum)
                {
                    leftSum = sum;
                    maxLeft = i;
                }
            }

            var rightSum = int.MinValue;
            sum = 0;
            var maxRight = mid + 1;
            for (int i = mid + 1; i <= high; i++)
            {
                sum += array[i];
                if (sum > rightSum)
                {
                    rightSum = sum;
                    maxRight = i;
                }
            }

            return (maxLeft, maxRight, leftSum + rightSum);
        }
        
        public static (int lowIndex, int highIndex, int sum) FindMaximumSubarrayNaive(int[] array)
        {
            var maxSum = int.MinValue;
            var maxLeft = 0;
            var maxRight = 0;

            for (int i = 0; i < array.Length; i++)
            {
                var curSum = 0;
                for (int j = i; j < array.Length; j++)
                {
                    curSum += array[j];
                    if (curSum > maxSum)
                    {
                        maxSum = curSum;
                        maxLeft = i;
                        maxRight = j;
                    }
                }
            }

            return (maxLeft, maxRight, maxSum);
        }
        
        public static (int lowIndex, int highIndex, int sum) FindMaximumSubarrayLinear(int[] array)
        {
            var maxSum = int.MinValue;
            var leftMax = -1;
            var rightMax = -1;
            var curSum = 0;
            var leftCur = 0;
            for (int i = 0; i < array.Length; i++)
            {
                curSum += array[i];
                if (curSum > maxSum)
                {
                    leftMax = leftCur;
                    rightMax = i;
                    maxSum = curSum;
                }

                if (curSum < 0)
                {
                    curSum = 0;
                    leftCur = i + 1;
                }
            }

            return (leftMax, rightMax, maxSum);
        }
    }
}