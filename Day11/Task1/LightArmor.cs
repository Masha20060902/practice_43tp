namespace Task1
{
    internal class LightArmor : IArmor //Легкая бронь
    {
        public void GetDefense()
        {
            Console.WriteLine("Вы приобрели легкую броню. Ваш уровень защиты увеличился на 10 единиц.");
        }
    }
}
