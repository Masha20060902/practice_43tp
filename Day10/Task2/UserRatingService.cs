namespace Task2
{
    internal class UserRatingService
    {
        public IRatingStrategy UserRatingServiceStrategy {  get; set; }
        public UserRatingService(IRatingStrategy _userRatingServiceStrategy)
        {
            UserRatingServiceStrategy = _userRatingServiceStrategy;
        }
        public void ExecuteAlgorithm()
        {
            UserRatingServiceStrategy.PrintRating();
        }
    }
}
