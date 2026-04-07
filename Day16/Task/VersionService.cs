using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Windows;
namespace Task
{
    public class VersionService
    {
        public ObservableCollection<DocumentNode> _doc = new();
        public DocumentNode _document = new();
        private string _path = "documents.json";
        public ObservableCollection<DocumentNode> Documents => _doc;
        public async System.Threading.Tasks.Task LoadVersion(IProgress<int>? progress = null)
        {
            await System.Threading.Tasks.Task.Delay(3000);
            if (!File.Exists(_path))
                return;
            var json = await File.ReadAllTextAsync(_path);
            var docs = JsonSerializer.Deserialize<List<DocumentNode>>(json);
            if (docs == null) return;
            Application.Current.Dispatcher.Invoke(() =>
            {
                _doc.Clear();
                foreach (var d in docs)
                    _doc.Add(d);
            });
            progress?.Report(100);
        }
        public void SaveVersion()
        {
            var json = JsonSerializer.Serialize(_doc, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(_path, json);
        }
        public void DeleteVersion(Document sender)
        {
            _document.Documents.Remove(sender);
        }
        public void AddVersion(int versionNumber, DateTime date, string author)
        {
            _document.Documents.Add(new Document
            {
                VersionNumber = versionNumber,
                Date = date,
                Author = author,
            });
        }
    }
}
