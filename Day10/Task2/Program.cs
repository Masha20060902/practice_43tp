namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите цифру (1, 2, 3): ");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num == 1)
            {
                var users = new UserRatingService(new SimpleRating());
                users.ExecuteAlgorithm();
                users.UserRatingServiceStrategy = new SimpleRating();
            }
            else if (num == 2)
            {
                var users = new UserRatingService(new ComplexRating());
                users.ExecuteAlgorithm();
                users.UserRatingServiceStrategy = new ComplexRating();
            }
            else if (num == 3)
            {
                var users = new UserRatingService(new MachineLearningRatingn());
                users.ExecuteAlgorithm();
                users.UserRatingServiceStrategy = new MachineLearningRatingn();
            }
        }
    }
}
