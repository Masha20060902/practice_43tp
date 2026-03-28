namespace Task1
{
    internal class MediumArmorFactory : ArmorFactory // Фабрика средней броони
    {
        public override IArmor CreateArmor()
        {
            return new MediumArmor();
        }
    }
}
