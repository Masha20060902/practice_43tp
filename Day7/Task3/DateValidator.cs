using System.Text.RegularExpressions;
namespace Task3
{
    internal class DateValidator
    {
        public void ValidateDate(string date)
        {
            var r = new Regex(@"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.(19|20)\d\d$");
            if (r.IsMatch(date))
            {
                Console.WriteLine("Дата корректна"); ;
            }
            else
            {
                throw new InvalidDateFormatException("Вызвано исключение: дата не корректная!!!");
            }
        }
    }
}
