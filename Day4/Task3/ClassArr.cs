namespace Task3
{
    internal class ClassArr
    {
        public static int ArraySum(int[] arr)
        {
            return ArraySum(arr, 0);
        }
        public static int ArraySum(int[] arr, int ind)
        {
            if (ind >= arr.Length)
            {
                return 0;
            }
            return arr[ind] + ArraySum(arr, ind + 1);
        }
    }
}
