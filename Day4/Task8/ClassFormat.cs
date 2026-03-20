namespace Task8
{
    internal class ClassFormat
    {
        public static void FormatText(in string text, out string formattedText)
        {
            formattedText = text.ToUpper();
        }
        public static void FormatText(in string text, bool toUpperCase, out string formattedText)
        {

            if (toUpperCase)
            {
                formattedText = text.ToUpper();
            }
            else
            {
                formattedText = text.ToLower();
            }
        }
    }
}
