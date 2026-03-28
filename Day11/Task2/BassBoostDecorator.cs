namespace Task2
{
    internal class BassBoostDecorator : IMusicPlayer
    {
        private IMusicPlayer _musicPlayer;

        public BassBoostDecorator(IMusicPlayer musicPlayer)
        {
            _musicPlayer = musicPlayer;
        }
        public string GetSoundQuality()
        {
            return _musicPlayer.GetSoundQuality() + " + добавлен басс";
        }
    }
}
