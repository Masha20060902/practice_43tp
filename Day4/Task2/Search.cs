namespace Task2
{
    public class Search
    {
        public void Minmax(ref double x, ref double y)
        {
            double a = x, b = y;
            x = Math.Min(a, b);
            y = Math.Max(a, b);
        }
    }
}
