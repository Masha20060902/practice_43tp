
namespace Task6
{
    internal class ClassTime
    {
        public static void DecTime(ref int h, ref int m, ref int s, int t)
        {
            int total = h * 3600 + m * 60 + s;
            total -= t;
            if (total < 0)
            {
                total = 0;
            }
            h = total / 3600;
            total %= 3600;
            m = total / 60;
            s = total % 60;
        }
    }
}
