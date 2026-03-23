using System.Text.RegularExpressions;

namespace Task2
{
    public delegate bool TextFilter(string text);
    internal class ClassText
    {
        public bool ConteinsDigit(string text)
        {
            string pattern = @"\d";
            var r = new Regex(pattern);
            return r.IsMatch(text);
        }
        public bool ContainsSpecialCharacters(string text)
        {
            string pattern = @"[^\p{L}\p{N} ]";
            var r = new Regex(pattern);
            return r.IsMatch(text);
        }
        public string[] FilterText(string[] text, TextFilter textFilter)
        {
            var result = new List<string>();
            foreach (var t in text)
            {
                if (textFilter(t))
                {
                    result.Add(t);
                }
            }
            return result.ToArray();
        }
    }
}
