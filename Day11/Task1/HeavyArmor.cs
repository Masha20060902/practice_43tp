namespace Task1
{
    internal class HeavyArmor : IArmor // Тяжелая бронь
    {
        public void GetDefense()
        {
            Console.WriteLine("Вы приобрели тяжелую броню. Ваш уровень защиты увеличился на 50 единиц.");
        }
    }
}
