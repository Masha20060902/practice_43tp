namespace Task3
{
    internal class UserManager<T> : IUserManager<T>
    {
        private UserStorage<T> userstorage;
        public UserManager()
        {
            userstorage = new UserStorage<T>();
        }
        public void AddUser(T user)
        {
            userstorage.Users.Add(user);
        }

        public void RemoveUser(T user)
        {
            userstorage.Users.Remove(user);
        }
        public void ShowUsers()
        {
            foreach (var user in userstorage.Users)
            {
                Console.WriteLine(user);
            }
        }
        public List<T> GetAllUsers()
        {
            return userstorage.Users;
        }
    }
}
