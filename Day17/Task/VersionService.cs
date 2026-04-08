using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
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
            await System.Threading.Tasks.Task.Delay(1000);
            if (!File.Exists(_path))
                return;

            var json = await File.ReadAllTextAsync(_path);
            var docs = JsonSerializer.Deserialize<List<DocumentNode>>(json);
            if (docs == null) return;
            foreach (var node in docs)
            {
                if (node.Documents == null || node.Documents.Count == 0)
                    continue;
                foreach (var d in node.Documents)
                    d.IsCurrent = false;
                var current = node.Documents
                    .OrderByDescending(d => d.VersionNumber)
                    .FirstOrDefault();

                if (current != null)
                    current.IsCurrent = true;
            }
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
            if (_document == null || _document.Documents == null)
                return;
            foreach (var v in _document.Documents)
            {
                v.IsNew = false;
                v.IsCurrent = false;
            }
            var newDoc = new Document
            {
                VersionNumber = versionNumber,
                Date = date,
                Author = author,
                IsNew = true,
                IsCurrent = true
            };
            _document.Documents.Add(newDoc);
            SaveVersion();
        }
        public void AddCommentToVersion(Document version, string title, string comment)
        {
            if (version == null) return;

            version.Title = title;
            version.Comment = comment;
            SaveVersion();
        }
    }
}
