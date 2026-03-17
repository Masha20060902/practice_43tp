namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вывод четных чисел в диапазоне.");
            Console.Write("Введите А: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите B: ");
            int b = Convert.ToInt32(Console.ReadLine());
            if (a <= b)
            {
                Console.WriteLine("Вывод четных чисел с диапазона от А включительно до В включительно(while).");
                int i = a;
                while (i <= b)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine(i);
                    }
                    i++;
                }
            }
            if (a <= b)
            {
                Console.WriteLine("Вывод четных чисел с диапазона от А включительно до В включительно(do while).");
                int i = a;
                do
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine(i);
                    }
                    i++;
                } while (i < b);
            }
            if (a <= b)
            {
                Console.WriteLine("Вывод четных чисел с диапазона от А включительно до В включительно(for).");
                for (int i = a; i <= b; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("А должно быть меньше либо равно В");
            }
        }
    }
}
