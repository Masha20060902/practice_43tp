namespace Task2
{
    internal class NoiseReductionDecorator : IMusicPlayer
    {
        private IMusicPlayer _musicPlayer;

        public NoiseReductionDecorator(IMusicPlayer musicPlayer)
        {
            _musicPlayer = musicPlayer;
        }
        public string GetSoundQuality()
        {
            return _musicPlayer.GetSoundQuality() + " + добавлено шумоподавление";
        }
    }
}
