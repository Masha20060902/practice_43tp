using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
namespace Task
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<DocumentNode> _doc;
        private DocumentNode _document = new();
        private string _path = "Kesh.data";
        public MainWindow()
        {
            InitializeComponent();
            _doc = new ObservableCollection<DocumentNode>();
            LoadVersion();
            DataContext = this;
        }
        public ObservableCollection<DocumentNode> Documents => _doc;
        public void _doc_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            MessageBox.Show("Добавлно", "", MessageBoxButton.OKCancel, MessageBoxImage.Information);
        }

        public void LoadVersion()
        {
            if (!File.Exists(_path))
                return;
            var lines = File.ReadAllLines(_path);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                string docName = parts[0];
                int version = int.Parse(parts[1]);
                DateTime date = DateTime.ParseExact(parts[2], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                string author = parts[3];
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
            }
        }
        public void SaveVersion()
        {

            var lines = new ObservableCollection<string>();

            foreach (var d in _doc)
            {
                foreach (var v in d.Documents)
                {
                    lines.Add($"{d.Name};{v.VersionNumber};{v.Date:dd.MM.yyyy};{v.Author}");
                }
            }
            File.WriteAllLines(_path, lines);
        }

        private void DocumentsTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (DocumentsTreeView.SelectedItem is DocumentNode docum)
            {
                _document = docum;
                DataGrid.ItemsSource = _document.Documents;
            }
        }
        private void AddVersionDoc_Click(object sender, RoutedEventArgs e)
        {
            AddVersionDocument add = new AddVersionDocument(this, _document);
            add.Owner = this;
            add.ShowDialog();
        }

        private void DeleteVersion_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem is Document selected)
            {
                if (MessageBox.Show("Вы точно хотите удалить этот элемент?",
                 "Удаление версии",
                 MessageBoxButton.YesNo,
                 MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    _document.Documents.Remove(selected);
                    SaveVersion();
                }
            }
            else
            {
                MessageBox.Show("Сначала выберите версию", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddDoc_Click(object sender, RoutedEventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Введите имя документа", "Новый документ", "Новый документ");
            if (string.IsNullOrWhiteSpace(name))
                return;
            var newDoc = new DocumentNode { Name = name };
            _doc.Add(newDoc);
            SaveVersion();
        }

        private void ViewHistory_Click(object sender, RoutedEventArgs e)
        {
            if (_document == null)
            {
                MessageBox.Show("Сначала выберите документ.", "История",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var win = new HistoryWindow(_document.Documents);
            win.Owner = this;
            win.ShowDialog();
        }
    }
}