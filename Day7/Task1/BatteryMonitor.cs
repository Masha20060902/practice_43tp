namespace Task1
{
    internal class BatteryMonitor
    {
        public void CheckBatteryLevel(int level)
        {
            if (level < 5)
            {
                throw new LowBatteryException("Заряд батареи ниже 5%!!!", new Exception("ошибка"));
            }
            else
            {
                Console.WriteLine("Пока можешь пользоваться");
            }
        }
    }
}
