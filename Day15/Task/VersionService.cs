using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Windows;
namespace Task
{
    public class VersionService
    {
        public ObservableCollection<DocumentNode> _doc = new ObservableCollection<DocumentNode>();
        public DocumentNode _document = new();
        private string _path = "Kesh.data";
        public ObservableCollection<DocumentNode> Documents => _doc;
        public VersionService()
        {
        }
        public async System.Threading.Tasks.Task LoadVersion(IProgress<int>? progress = null)
        {
            await System.Threading.Tasks.Task.Delay(3000);
            if (!File.Exists(_path))
                return;
            var lines = await File.ReadAllLinesAsync(_path);
            int total = lines.Length;
            int processed = 0;
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                string docName = parts[0];
                int version = int.Parse(parts[1]);
                DateTime date = DateTime.ParseExact(parts[2], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                string author = parts[3];

                Application.Current.Dispatcher.Invoke(() =>
                {
                    var d = _doc.FirstOrDefault(x => x.Name == docName);
                    if (d == null)
                    {
                        d = new DocumentNode { Name = docName };
                        _doc.Add(d);
                    }

                    d.Documents.Add(new Document
                    {
                        VersionNumber = version,
                        Date = date,
                        Author = author
                    });
                });

                processed++;
                int percent = total == 0 ? 0 : processed * 100 / total;
                progress?.Report(percent);
            }
        }
        public void SaveVersion()
        {
            var lines = new ObservableCollection<string>();

            foreach (var d in _doc)//
            {
                foreach (var v in d.Documents)
                {
                    lines.Add($"{d.Name};{v.VersionNumber};{v.Date:dd.MM.yyyy};{v.Author}");
                }
            }
            File.WriteAllLines(_path, lines);
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
