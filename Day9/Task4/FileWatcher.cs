namespace Task4
{
    internal class FileWatcher
    {
        private FileSystemWatcher watcher;
        private string filename = "files_list.txt";
        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            string ext = Path.GetExtension(e.FullPath).ToLower();
            if (ext == ".txt" || ext == ".csv" || ext == ".xml")
            {
                File.AppendAllText(filename, e.Name + "\r\n");
                Console.WriteLine($"Создан {e.Name} (записан в {filename})");
            }
            else
            {
                Console.WriteLine($"Создан {e.Name}");
            }
        }
        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Удален {e.Name}");
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Изменен {e.Name}");
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"Переименован {e.OldName} в {e.Name}");
        }
        public FileWatcher(string path)
        {
            watcher = new FileSystemWatcher(path);
            watcher.IncludeSubdirectories = false;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Changed += OnChanged;
            watcher.Renamed += OnRenamed;
            watcher.EnableRaisingEvents = true;
        }
    }
}
