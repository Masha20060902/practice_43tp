using System.Windows;
namespace Task
{
    public partial class AddVersionDocument : Window
    {
        private VersionService _versionService;
        private MainWindow _mainWindow;
        public AddVersionDocument(MainWindow mainWindow,VersionService versionService)
        {
            InitializeComponent();
            _versionService = versionService;
            _mainWindow = mainWindow;
            _versionService._document.Documents.CollectionChanged += _mainWindow._doc_CollectionChanged;
        }

        private void AddV_Click(object sender, RoutedEventArgs e)
        {
            _versionService.AddVersion(Convert.ToInt32(Version.Text), Convert.ToDateTime(Date.Text), Author.Text);
            _versionService.SaveVersion();
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
           
            this.Close();
        }
    }
}
