namespace Task1
{
    class HeavyArmorFactory : ArmorFactory// Фабрика тяжелой брони
    {
        public override IArmor CreateArmor()
        {
            return new HeavyArmor();
        }
    }
}
