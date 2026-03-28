namespace Task1
{
    internal class MediumArmor : IArmor //Средняя бронь
    {
        public void GetDefense()
        {
            Console.WriteLine("Вы приобрели среднюю броню. Ваш уровень защиты увеличился на 30 единиц.");
        }
    }
}
