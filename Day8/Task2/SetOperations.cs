namespace Task2
{
    internal class SetOperations<T>
    {
        private Random random = new Random();
        public MySet<int> AddSet(int n)
        {
            var set = new MySet<int>();
            for (int i = 0; i < n; i++)
            {
                set.Add(random.Next(1, 20));
            }
            return set;
        }
        public MySet<int> UnionSet(MySet<int> a, MySet<int> b)
        {
            var result = new MySet<int>();
            foreach (var x in a)
            {
                result.Add(x);
            }
            result.Union(b);
            return result;
        }
        public MySet<int> IntersectSet(MySet<int> a, MySet<int> b)
        {
            var result = new MySet<int>();
            foreach (var x in a)
            {
                result.Add(x);
            }
            result.Intersect(b);
            return result;
        }
        public void Print(MySet<int> values)
        {
            foreach (var x in values)
            {
                Console.Write($"{x}   ");
            }
        }
    }
}
