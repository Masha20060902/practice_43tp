namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = new CarPartService();
            Console.Write("Введите количество деталей: ");
            int n = Convert.ToInt32(Console.ReadLine());
            CarPart[] parts = service.CreateRandomParts(n);
            Console.WriteLine("\nВсе детали:");
            for (int i = 0; i < parts.Length; i++)
            {
                Console.WriteLine(parts[i]);
            }
            Console.WriteLine("Выберите фильтрацию");
            Console.WriteLine("1: только механические детали");
            Console.WriteLine("2: только электрические детали");
            Console.WriteLine("3: без фильтра (все детали)");
            int filter = Convert.ToInt32(Console.ReadLine());
            CarPart[] filtered;
            if (filter == 1)
            {
                filtered = service.GetMechanicalParts(parts);
            }
            else if (filter == 2)
            {
                filtered = service.GetElectricalParts(parts);
            }
            else
            {
                filtered = parts;
            }
            Console.WriteLine("Как отсортировать детали по номеру?");
            Console.WriteLine("1: по возрастанию");
            Console.WriteLine("2: по убыванию");
            int sort = Convert.ToInt32(Console.ReadLine());
            bool ascending;
            if (sort == 1)
            {
                ascending = true;
            }
            else
            {
                ascending = false;
            }
            service.SortPartsByName(filtered, ascending);
            Console.WriteLine("Результат:");
            for (int i = 0; i < filtered.Length; i++)
            {
                Console.WriteLine(filtered[i]);
            }
        }
    }
}
