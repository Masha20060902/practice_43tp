namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите номер масти от 1 включительно до 4 включительно: ");
            int m = Convert.ToInt32(Console.ReadLine());
            if (m >= 1 && m <= 4)
            {
                switch (m)
                {
                    case 1:
                        Console.Write("Ваша масть: пики");
                        break;
                    case 2:
                        Console.Write("Ваша масть: трефы");
                        break;
                    case 3:
                        Console.Write("Ваша масть: бубны");
                        break;
                    case 4:
                        Console.Write("Ваша масть: червы");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Такой масти нет.");
            }
        }
    }
}
