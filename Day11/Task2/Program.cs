namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMusicPlayer basicMusic = new BasicMusicPlayer();
            Console.WriteLine("Что вы хотите улучшить?");
            while (true)
            {
                Console.WriteLine("Бассы - 1\nШумоподавление - 2\nЧастоту - 3");
                int num = Convert.ToInt32(Console.ReadLine());
                if (num == 0)
                {
                    break;
                }
                if (num == 1)
                {
                    basicMusic = new BassBoostDecorator(basicMusic);
                    Console.WriteLine(basicMusic.GetSoundQuality());
                }
                else if (num == 2)
                {
                    basicMusic = new NoiseReductionDecorator(basicMusic);
                    Console.WriteLine(basicMusic.GetSoundQuality());
                }
                else if (num == 3)
                {
                    basicMusic = new EqualizerDecorator(basicMusic);
                    Console.WriteLine(basicMusic.GetSoundQuality());
                }
                Console.WriteLine("Что-то еще хотите улучшить? (для выхода нажмите 0)");
            }
        }
    }
}
