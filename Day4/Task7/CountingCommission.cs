namespace Task7
{
    internal class CountingCommission
    {
        public static double CalculateCommission(double sales)
        {
            return sales * 0.10;
        }
        public static double CalculateCommission(double sales, bool isVIP)
        {
            if (isVIP)
            {
                return sales * 0.15;
            }
            return CalculateCommission(sales);
        }
    }
}
