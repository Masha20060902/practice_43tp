namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину списка множеств: ");
            int n = Convert.ToInt32(Console.ReadLine());
            var setoperationn = new SetOperations<int>();
            var list1 = setoperationn.AddSet(n);
            Console.WriteLine("Первый список: ");
            setoperationn.Print(list1);
            var list2 = setoperationn.AddSet(n);
            Console.WriteLine();
            Console.WriteLine("Второй список: ");
            setoperationn.Print(list2);
            Console.WriteLine();
            Console.WriteLine("Объединение: ");
            var unionset = setoperationn.UnionSet(list1, list2);
            setoperationn.Print(unionset);
            Console.WriteLine();
            Console.WriteLine("Пересечение: ");
            var inter = setoperationn.IntersectSet(list1, list2);
            setoperationn.Print(inter);
        }
    }
}
