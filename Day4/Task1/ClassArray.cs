namespace Task1
{
    public class ClassArray
    {
        public static int[] GenerationArray(int n)
        {
            var r = new Random();
            var arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = r.Next(-70, 100);
            }
            return arr;
        }
        public static int SearchIndex(int element, int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] == element)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
