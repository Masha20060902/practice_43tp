using System.IO;
using System.Windows;

namespace Task
{
    class UsersFileWatcher : IDisposable
    {
        private FileSystemWatcher _filesistemwatcher;
        private DateTime _lastNotifyTime;
        private string _lastFileName = "";
        private WatcherChangeTypes _lastChangeType;
        public UsersFileWatcher(string directoryPath, string fileName)
        {
            _filesistemwatcher = new FileSystemWatcher(directoryPath)
            {
                Filter = fileName,
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size
            };
            _filesistemwatcher.Changed += OnChanged;
            _filesistemwatcher.Created += OnChanged;
            _filesistemwatcher.Deleted += OnChanged;
            _filesistemwatcher.Renamed += OnRenamed;
            _filesistemwatcher.EnableRaisingEvents = true;
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            var now = DateTime.Now;
            if (e.Name == _lastFileName &&
                e.ChangeType == _lastChangeType &&
                (now - _lastNotifyTime).TotalMilliseconds < 500)
            {
                return;
            }

            _lastFileName = e.Name;
            _lastChangeType = e.ChangeType;
            _lastNotifyTime = now;
            Application.Current.Dispatcher.Invoke(() =>
            {
                MessageBox.Show(
                    $"Файл пользователей \"{e.Name}\" был {e.ChangeType}",
                    "Изменение файла пользователей");
            });
        }
        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                MessageBox.Show(
                    $"Файл пользователей переименован:\n{e.OldName} -> {e.Name}",
                    "Изменение файла пользователей");
            });
        }
        public void Dispose()
        {
            _filesistemwatcher.EnableRaisingEvents = false;
            _filesistemwatcher.Dispose();
        }
    }
}
