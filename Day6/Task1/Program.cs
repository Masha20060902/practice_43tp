namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var multi = new MultiplyByTwo();
            var filtereven = new FilterEvenNumbers();
            ListProcessor del = multi.DublNum;
            ListProcessor del2 = filtereven.Filter;
            var list = new List<int>();
            Console.Write("Введите длину списка: ");
            int n = Convert.ToInt32(Console.ReadLine());
            var r = new Random();
            Console.WriteLine("Начальный список: ");
            for (int i = 0; i < n; i++)
            {
                list.Add(r.Next(1, 20));
            }
            foreach (int l1 in list)
            {
                Console.Write($"{l1}  ");
            }
            Console.WriteLine();
            Console.WriteLine("Список четных: ");
            foreach (int l2 in del2(list))
            {
                Console.Write($"{l2}  ");
            }
            Console.WriteLine();
            Console.WriteLine("Результат умножения: ");
            foreach (int l3 in del(list))
            {
                Console.Write($"{l3}  ");
            }
        }
    }
}
