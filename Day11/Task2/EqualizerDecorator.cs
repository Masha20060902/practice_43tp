namespace Task2
{
    internal class EqualizerDecorator : IMusicPlayer
    {
        private IMusicPlayer _musicPlayer;

        public EqualizerDecorator(IMusicPlayer musicPlayer)
        {
            _musicPlayer = musicPlayer;
        }
        public string GetSoundQuality()
        {
            return _musicPlayer.GetSoundQuality() + " + добавлен настраиваемый эквалайзер";
        }
    }
}
