using System.IO;
using System.Windows;

namespace Task
{
    class UsersFileWatcher : IDisposable
    {
        private FileSystemWatcher _filesistemwatcher;
        private DateTime _lastNotifyTime;
        public UsersFileWatcher(string directoryPath, string fileName)
        {
            _filesistemwatcher = new FileSystemWatcher(directoryPath)
            {
                Filter = fileName,
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size
            };
            _filesistemwatcher.Changed += OnChanged;
            _filesistemwatcher.Renamed += OnRenamed;
            _filesistemwatcher.EnableRaisingEvents = true;
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            ShowDebouncedMessage($"Файл пользователей \"{e.Name}\" был {e.ChangeType}");
        }
        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            ShowDebouncedMessage($"Файл пользователей \"{e.Name}\" был {e.ChangeType}");
        }
        public void Dispose()
        {
            _filesistemwatcher.EnableRaisingEvents = false;
            _filesistemwatcher.Dispose();
        }
        private void ShowDebouncedMessage(string text)
        {
            var now = DateTime.Now;

            if ((now - _lastNotifyTime).TotalSeconds < 2)
                return;

            _lastNotifyTime = now;

            Application.Current.Dispatcher.Invoke(() =>
            {
                MessageBox.Show(text, "Изменение файла пользователей");
            });
        }
    }
}
