namespace Task1
{
    internal class FilterEvenNumbers
    {
        public List<int> Filter(List<int> values)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] % 2 == 0)
                {
                    list.Add(values[i]);
                }
            }
            return list;
        }
    }
}
