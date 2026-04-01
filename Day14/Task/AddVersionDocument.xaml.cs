using System.Globalization;
using System.Windows;

namespace Task
{
    public partial class AddVersionDocument : Window
    {
        private MainWindow _mainWindow;
        private DocumentNode _document;
        public AddVersionDocument(MainWindow mainWindow, DocumentNode document)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _document = document;
            _document.Documents.CollectionChanged += _mainWindow._doc_CollectionChanged;
        }

        private void AddV_Click(object sender, RoutedEventArgs e)
        {
            var doc3 = new Document
            {
                VersionNumber = Convert.ToInt32(Version.Text),
                Date = DateTime.ParseExact(Date.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture),
                Author = Author.Text
            };
            _document.Documents.Add(doc3);
            _mainWindow.SaveVersion();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
