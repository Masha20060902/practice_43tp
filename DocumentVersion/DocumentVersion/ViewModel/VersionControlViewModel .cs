using DocumentVersion.Common;
using DocumentVersion.Data;
using DocumentVersion.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
namespace DocumentVersion.ViewModel
{
    public class VersionControlViewModel : INotifyPropertyChanged
    {
        private readonly DocsContext _context;
        private readonly DocumentRepository _documentRepository;
        private readonly VersionRepository _versionRepository;

        public ObservableCollection<DocumentEntity> Documents { get; } = new();
        public ObservableCollection<VersionEntity> Versions { get; } = new();

        private DocumentEntity _selectedDocument;
        public DocumentEntity SelectedDocument
        {
            get => _selectedDocument;
            set
            {
                _selectedDocument = value;
                OnPropertyChanged();
                _ = LoadVersionsForSelectedDocument();
            }
        }

        private VersionEntity _selectedVersion;
        public VersionEntity SelectedVersion
        {
            get => _selectedVersion;
            set { _selectedVersion = value; OnPropertyChanged(); }
        }

        public ICommand ShowFirstVersionCommand { get; }
        public ICommand AddVersionCommand { get; }
        public ICommand DeleteVersionCommand { get; }

        public VersionControlViewModel()
        {
            _context = new DocsContext();
            _documentRepository = new DocumentRepository(_context);
            _versionRepository = new VersionRepository(_context);

            ShowFirstVersionCommand = new RelayCommand(ShowFirstVersion);
            DeleteVersionCommand = new RelayCommand(async () => await DeleteVersionAsync(), () => SelectedVersion != null);

            _ = LoadDocumentsAsync();
        }

        public async Task LoadDocumentsAsync()
        {
            Documents.Clear();
            var docs = await _documentRepository.GetAllAsync();
            foreach (var d in docs)
                Documents.Add(d);
        }

        public async Task LoadVersionsForSelectedDocument()
        {
            Versions.Clear();
            if (SelectedDocument == null) return;

            var versions = SelectedDocument.Versions
                .OrderBy(v => v.VersionNumber)
                .ToList();
            foreach (var v in versions)
                v.IsCurrent = false;

            var current = versions.LastOrDefault();
            if (current != null)
                current.IsCurrent = true;
            foreach (var v in versions)
                Versions.Add(v);
        }

        public void ShowFirstVersion()
        {
            if (Versions == null || Versions.Count == 0)
            {
                MessageBox.Show("Нет версий у выбранного документа");
                return;
            }

            var first = Versions[0];
            MessageBox.Show(
                $"Версия: {first.VersionNumber}\nДата: {first.CreatedAt}\nАвтор: {first.Author}",
                "Первая версия");
        }

        public async Task AddVersionAsync(int versionNumber, DateTime createdAt, string author)
        {
            if (SelectedDocument == null) return;

            var ver = new VersionEntity
            {
                DocumentId = SelectedDocument.Id,
                VersionNumber = versionNumber,
                CreatedAt = createdAt,
                Author = author,
                Title = "Новая версия " + versionNumber,
                Comment = ""
            };

            await _versionRepository.AddAsync(ver);
            Versions.Add(ver);

            foreach (var v in Versions)
                v.IsCurrent = false;
            ver.IsCurrent = true;
        }

        public async Task DeleteVersionAsync()
        {
            if (SelectedVersion == null) return;

            if (MessageBox.Show("Удалить выбранную версию?", "Удаление",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
                return;

            await _versionRepository.DeleteAsync(SelectedVersion);
            Versions.Remove(SelectedVersion);
            SelectedVersion = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
