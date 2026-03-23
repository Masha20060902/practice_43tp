namespace Task1
{
    delegate List<int> ListProcessor(List<int> values);
    internal class MultiplyByTwo
    {
        public List<int> DublNum(List<int> values)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < values.Count; i++)
            {
                values[i] *= 2;
                list.Add(values[i]);
            }
            return list;
        }
    }
}
