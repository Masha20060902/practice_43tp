using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
namespace Task
{
    public partial class MainWindow : Window
    {
        private VersionService versionService;
        private readonly VersionControlViewModel _vm;
        public MainWindow()
        {
            InitializeComponent();
            versionService = new VersionService();
            _vm = new VersionControlViewModel(versionService);
            DataContext = _vm;
            Loaded += MainWindow_Loaded;
        }
        public ObservableCollection<DocumentNode> Documents
        => versionService.Documents;
        public void _doc_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            MessageBox.Show("Добавлно", "", MessageBoxButton.OKCancel, MessageBoxImage.Information);
        }
         private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadingOverlay.Visibility = Visibility.Visible;
            DataGrid.Visibility = Visibility.Hidden;
            LoadProgress.IsIndeterminate = true;
            LoadProgress.Value = 0;

            var progress = new Progress<int>(p =>
            {
                LoadProgress.IsIndeterminate = false;
                LoadProgress.Value = p;
            });
            await System.Threading.Tasks.Task.Delay(3000);
            await versionService.LoadVersion(progress);
            LoadingOverlay.Visibility = Visibility.Collapsed;
            DataGrid.Visibility = Visibility.Visible;
        }
        private void DocumentsTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (DocumentsTreeView.SelectedItem is DocumentNode docum)
            {
                _vm.SelectedNode = docum;
                versionService._document = docum;
                DataGrid.ItemsSource = _vm.Versions;
            }
        }
        private void AddVersionDoc_Click(object sender, RoutedEventArgs e)
        {
            var win = new AddVersionDocument(this,versionService);
            win.Owner = this;
            win.ShowDialog();
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
                    versionService.DeleteVersion(selected);
                }
            }
            else
            {
                MessageBox.Show("Сначала выберите версию", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            versionService.SaveVersion();
        }

        private void AddDoc_Click(object sender, RoutedEventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Введите имя документа", "Новый документ", "Новый документ");
            if (string.IsNullOrWhiteSpace(name))
                return;
            var newDoc = new DocumentNode { Name = name };
            Documents.Add(newDoc);
            versionService.SaveVersion();
        }

        private void ViewHistory_Click(object sender, RoutedEventArgs e)
        {
            if (versionService._document == null)
            {
                MessageBox.Show("Сначала выберите документ.", "История",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var win = new HistoryWindow(versionService._document.Documents);
            win.Owner = this;
            win.ShowDialog();
        }
    }
}