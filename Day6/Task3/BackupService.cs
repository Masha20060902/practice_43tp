namespace Task3
{
    internal class BackupService
    {
        private string pathcopy = "Backup\\copy_file.txt";
        public void Backup(string filename)
        {
            Console.WriteLine("Сделана резервная копия.");
            File.Copy(filename, pathcopy, true);
        }
    }
}
