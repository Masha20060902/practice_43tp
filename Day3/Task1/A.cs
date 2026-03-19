namespace Task1
{
    public class A
    {
        private int a;
        private int b;
        public A(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public double Calculation()
        {
            double result = a * Math.Sqrt(b) - Math.Sin(a);
            return result;
        }
        public double Exponentiation()
        {
            double res = Math.Pow(a * b, 3);
            return res;
        }
    }
}
