namespace Task2
{
    internal class OrderFileReader
    {
        private string _fileorder = "file.data";
        private List<Order> _orders;
        public OrderFileReader(string fileorder, List<Order> orders)
        {
            _fileorder = fileorder;
            _orders = orders;
        }
        public bool VerifyFile()
        {
            bool result = false;
            using (StreamReader reader = new StreamReader(_fileorder))
            {
                string line = reader.ReadToEnd();
                foreach (var order in _orders)
                {
                    string t = order.ToString();
                    if (line.Contains(t))
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
    }
}
