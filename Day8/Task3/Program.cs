namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var logic = new ManagementClass();
            Console.WriteLine("Введите кол-во пользователей: ");
            int countUser = Convert.ToInt32(Console.ReadLine());
            var users = logic.CreateUser(countUser);
            logic.AddUsers(users);
            Console.WriteLine("Все пользователи: ");
            logic.userManager.ShowUsers();
            Console.WriteLine("Введите индекс пользователя для удаления (начиная с 0): ");
            int index = Convert.ToInt32(Console.ReadLine());
            logic.UserRemove(index);
            Console.WriteLine("После удаления:");
            logic.userManager.ShowUsers();
            Console.WriteLine("Введите Id пользователя для поиска: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var g = logic.SearchUser(id);
            Console.WriteLine("Результат поиска:");
            if (g.Count == 0)
            {
                Console.WriteLine("Пользователь с таким Id не найден.");
            }
            else
            {
                foreach (var u in g)
                {
                    Console.WriteLine(u);
                }
            }
            Console.WriteLine("Как отсортировать пользователей: 1 - по возрастанию Id, 2 - по убыванию: ");
            int sort = Convert.ToInt32(Console.ReadLine());
            var sorted = logic.SortUsers(sort);
            Console.WriteLine("Отсортированный список: ");
            foreach (var u in sorted)
            {
                Console.WriteLine(u);
            }
        }
    }
}
