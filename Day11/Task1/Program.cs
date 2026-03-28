
namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArmorFactory factory;
            IArmor armor;
            Console.WriteLine("Какую вы хотите приобрести броню?");
            Console.WriteLine("Легкая броня - 1(цена 5 р.);\nСредняя броня - 2(цена 10 р.)\nТяжелая броня - 3(цена 20 р.)");
            int typearmor = Convert.ToInt32(Console.ReadLine());
            if (typearmor == 1)
            {
                factory = new LightArmorFactory();
                (armor = factory.CreateArmor()).GetDefense();
            }
            else if (typearmor == 2)
            {
                factory = new MediumArmorFactory();
                (armor = factory.CreateArmor()).GetDefense();
            }
            else if (typearmor == 3)
            {
                factory = new HeavyArmorFactory();
                (armor = factory.CreateArmor()).GetDefense();
            }
            else
            {
                Console.WriteLine("Неизвестный тип брони");
            }
        }
    }
}
