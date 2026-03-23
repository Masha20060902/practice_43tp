namespace Task3
{
    public delegate void FileChengedHandler(string path);
    internal class FileWatcher
    {
        public event FileChengedHandler FileChanged;
        public void ChangedFile(string path)
        {
            FileChanged?.Invoke(path);
        }
    }
}
