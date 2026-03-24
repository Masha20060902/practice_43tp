namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите заряд батареи (без %): ");
            int level = Convert.ToInt32(Console.ReadLine());
            BatteryMonitor bm = new BatteryMonitor();
            try
            {
                bm.CheckBatteryLevel(level);
            }
            catch (LowBatteryException lb)
            {
                Console.WriteLine("Вызвано исключение: батарея ниже 5%!!!");
            }
        }
    }
}
