namespace Task4
{
    public static class ArrayCLass
    {
        public static int[] Unique(this int[] arr)
        {
            return arr.Distinct().ToArray();
        }
    }
}
