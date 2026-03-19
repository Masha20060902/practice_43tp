namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите кол-во работников: ");
            int count = Convert.ToInt32(Console.ReadLine());
            Employee[] employees = ArrayOfEmployees.Generation(count);
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.Name}, возраст: {emp.Age} лет");
            }
            Console.WriteLine("Отсортированный массив: ");
            ArrayOfEmployees.SortArray(employees);
            foreach (var e in employees)
            {
                Console.WriteLine($"{e.Name}, возраст: {e.Age} лет");
            }
            var old = ArrayOfEmployees.FindOldestEmployee(employees);
            Console.WriteLine($"Старший сотрудник: {old.Name} возраст {old.Age} лет");
            var statistics = ArrayOfEmployees.StatisticsByYear(employees);
            Console.WriteLine($"Средний возраст сотрудников: {statistics:0} лет");
            Console.Write("Введите возраст для фильтрации: ");
            int age = Convert.ToInt32(Console.ReadLine());
            var a = ArrayOfEmployees.Filter(employees, age);
            foreach (var e in a)
            {
                Console.WriteLine($"{e.Name}, возраст: {e.Age} лет");
            }
        }
    }
}
