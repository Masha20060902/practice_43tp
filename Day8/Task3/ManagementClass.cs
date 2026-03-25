namespace Task3
{
    internal class ManagementClass
    {
        public UserManager<User> userManager = new UserManager<User>();
        private Random r = new Random();
        public void AddUsers(List<User> users)
        {
            foreach (var user in users)
            {
                userManager.AddUser(user);
            }
        }
        public List<User> CreateUser(int countUser)
        {
            var users = new List<User>(countUser);
            for (int i = 0; i < countUser; i++)
            {
                int id = r.Next(1, 100);
                Console.Write($"Введите имя {i} пользователя: ");
                string name = Console.ReadLine();
                var user = new User
                {
                    Id = id,
                    Name = name
                };

                users.Add(user);
            }
            return users;
        }
        public void UserRemove(int index)
        {
            var users = userManager.GetAllUsers();
            var user = users[index];
            userManager.RemoveUser(user);
        }
        public List<User> SearchUser(int index)
        {
            var res = new List<User>();
            foreach (var u in userManager.GetAllUsers())
            {
                if (u.Id == index)
                    res.Add(u);
            }
            return res;
        }
        public List<User> SortUsers(int sort)
        {
            var users = new List<User>(userManager.GetAllUsers());
            users.Sort(CompareUsersById);
            if (sort == 2)
            {
                users.Reverse();
            }
            return users;
        }
        private static int CompareUsersById(User a, User b)
        {
            return a.Id.CompareTo(b.Id);
        }
    }
}
