namespace Task1
{
    internal class LightArmorFactory : ArmorFactory//Фабрика легкой брони
    {
        public override IArmor CreateArmor()
        {
            return new LightArmor();
        }
    }
}
