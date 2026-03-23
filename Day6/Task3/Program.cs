namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();//подписчик
            FileWatcher fw = new FileWatcher();//событие
            BackupService bs = new BackupService();//подписчик
            fw.FileChanged += bs.Backup;
            fw.FileChanged += logger.OnFileChanged;
            fw.ChangedFile("file.txt");
        }
    }
}
