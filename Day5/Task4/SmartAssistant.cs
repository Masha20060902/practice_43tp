namespace Task4
{
    internal class SmartAssistant : ITextAssistant, IVoiceAssistant
    {
        void ITextAssistant.Respond(string query)
        {
            Console.WriteLine($"Вы спросили: {query}");
        }
        void IVoiceAssistant.Respond(string query)
        {
            Console.WriteLine($"Озвучиваю запрос: {query}");
        }
    }
}
