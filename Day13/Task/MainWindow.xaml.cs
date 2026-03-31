using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Document> doc = new List<Document>();
        private Document document;
        private string path = "Kesh.data";
        public MainWindow()
        {
            InitializeComponent();
            LoadVersion();
            FillTree();
        }
        public void LoadVersion()
        {
            doc = new List<Document>();
            if (!File.Exists(path))
                return;
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                string docName = parts[0];
                int version = int.Parse(parts[1]);
                DateTime date = DateTime.ParseExact(parts[2], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                string author = parts[3];
                var d = doc.FirstOrDefault(x => x.Name == docName);
                if (d == null)
                {
                    d = new Document { Name = docName };
                    doc.Add(d);
                }
                d.documents.Add(new Documents
                {
                    VersionNumber = version,
                    Date = date,
                    Author = author
                });
            }
        }
        public void SaveVersion()
        {
            var lines = new List<string>();

            foreach (var d in doc)
            {
                foreach (var v in d.documents)
                {
                    lines.Add($"{d.Name};{v.VersionNumber};{v.Date:dd.MM.yyyy};{v.Author}");
                }
            }
            File.WriteAllLines(path, lines);
        }
        private void FillTree()
        {
            DocumentsTreeView.Items.Clear();
            foreach (var d in doc)
            {
                var item = new TreeViewItem
                {
                    Header = d.Name,
                    Tag = d
                };
                DocumentsTreeView.Items.Add(item);
            }
        }
        private void DocumentsTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var item = DocumentsTreeView.SelectedItem as TreeViewItem;
            if (item == null)
            {
                return;
            }
            if (item.Tag is Document docum)
            {
                document = docum;
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = document.documents;
            }
        }
        private void AddVersionDoc_Click(object sender, RoutedEventArgs e)
        {
            AddVersionDocument add = new AddVersionDocument(this, document);
            add.Owner = this;
            add.ShowDialog();
        }

        private void DeleteVersion_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem is Documents selected)
            {
                if (MessageBox.Show("Вы точно хотите удалить этот элемент?",
                 "Удаление версии",
                 MessageBoxButton.YesNo,
                 MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    document.documents.Remove(selected);
                    DataGrid.ItemsSource = null;
                    DataGrid.ItemsSource = document.documents;
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
            var newDoc = new Document { Name = name };
            doc.Add(newDoc);
            FillTree();
            SaveVersion();
        }

        private void ViewHistory_Click(object sender, RoutedEventArgs e)
        {
            if (document == null)
            {
                MessageBox.Show("Сначала выберите документ.", "История",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var win = new HistoryWindow(document.documents);
            win.Owner = this;
            win.ShowDialog();
        }
    }
}