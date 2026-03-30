using System.Globalization;
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
        public MainWindow()
        {
            InitializeComponent();
            InitializeList();
            FillTree();
        }
        private void InitializeList()
        {
            var doc1 = new Document { Name = "Практика" };
            doc1._documents.Add(new Documents
            {
                VersionNumber = 1,
                Date = DateTime.Now,
                Author = "Маша"
            });
            doc1._documents.Add(new Documents
            {
                VersionNumber = 2,
                Date = DateTime.Now,
                Author = "Маша"
            });
            var doc2 = new Document { Name = "Курсовая" };
            doc2._documents.Add(new Documents
            {
                VersionNumber = 1,
                Date = DateTime.UtcNow,
                Author = "Маша"
            });
            doc.Add(doc1);
            doc.Add(doc2);
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
                DataGrid.ItemsSource = document._documents;
            }
        }
        private void AddVersion_Click(object sender, RoutedEventArgs e)
        {
            var doc3 = new Documents
            {
                VersionNumber = Convert.ToInt32(Version.Text),
                Date = DateTime.ParseExact(Date.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture),
                Author = Author.Text
            };
            document._documents.Add(doc3);
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = document._documents;
        }
    }
}