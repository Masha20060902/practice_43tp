namespace Task3
{
    internal class UserStorage<T>
    {
        private List<T> users = new List<T>();
        public List<T> Users
        {
            get { return users; }
        }
    }
}
