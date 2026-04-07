using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Task
{
    internal class VersionControlViewModel : INotifyPropertyChanged
    {
        private readonly VersionService _service;
        public ObservableCollection<DocumentNode> Documents
            => _service.Documents;

        private DocumentNode _selectedNode;
        public DocumentNode SelectedNode
        {
            get => _selectedNode;
            set
            {
                _selectedNode = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Versions));
            }
        }
        public ObservableCollection<Document> Versions
            => SelectedNode?.Documents;
        public ICommand ShowFirstVersionCommand { get; }
        public VersionControlViewModel(VersionService service)
        {
            _service = service;
            ShowFirstVersionCommand = new RelayCommand(ShowFirstVersion);
        }

        private void ShowFirstVersion()
        {
            if (SelectedNode == null || SelectedNode.Documents == null || SelectedNode.Documents.Count == 0)
            {
                MessageBox.Show("Нет версий у выбранного документа");
                return;
            }

            Document first = SelectedNode.Documents[0];
            MessageBox.Show(
                $"Версия: {first.VersionNumber}\nДата: {first.Date:d}\nАвтор: {first.Author}","Первая версия");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
