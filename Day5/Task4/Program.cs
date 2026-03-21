namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var assistant = new SmartAssistant();
            ITextAssistant text = assistant;
            IVoiceAssistant voice = assistant;
            Console.Write("Введите текстовый запрос: ");
            string textQuery = Console.ReadLine();
            text.Respond(textQuery);
            Console.Write("Введите голосовой запрос: ");
            string voiceQuery = Console.ReadLine();
            voice.Respond(voiceQuery);
        }
    }
}
