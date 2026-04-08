using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Xml.Linq;
namespace Task
{
    public partial class MainWindow : Window
    {
        private VersionService versionService;
        private VersionControlViewModel _vm;
        private UsersFileWatcher _usersWatcher;
        public MainWindow()
        {
            InitializeComponent();
            versionService = new VersionService();
            _vm = new VersionControlViewModel(versionService);
            DataContext = _vm;
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            _usersWatcher = new UsersFileWatcher(dir, "users.json");
            Loaded += MainWindow_Loaded;

        }
        public ObservableCollection<DocumentNode> Documents
        => versionService.Documents;
        public void _doc_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            MessageBox.Show("Добавлно", "", MessageBoxButton.OKCancel, MessageBoxImage.Information);
        }
        protected override void OnClosed(EventArgs e)
        {
            _usersWatcher?.Dispose();
            base.OnClosed(e);
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
            await System.Threading.Tasks.Task.Delay(1000);
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
                var current = docum.Documents?.FirstOrDefault(d => d.IsCurrent);
                if (current != null)
                    DataGrid.SelectedItem = current;
            }

        }
        private void AddVersionDoc_Click(object sender, RoutedEventArgs e)
        {
            var win = new AddVersionDocument(this, versionService);
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

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Сделать этот клиент СЕРВЕРОМ чата?\n\n" + 
                "Да – сервер (слушает и показывает сообщения).\n" +
                "Нет – только клиент (только отправляет).",
                "Режим чата",
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Cancel)
                return;

            bool isServer = result == MessageBoxResult.Yes;

            var chat = new Chat(isServer);
            chat.Owner = this;
            chat.Show();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid.SelectedItem is not Document selected)
                return;
            VerNumber.Text = $"Версия: {selected.VersionNumber}";
            VerDate.Text = $"Дата: {selected.Date:d}";
            VerAuthor.Text = $"Автор: {selected.Author}";
            VerComment.Text = selected.Comment;
            VersionContent.Opacity = 0;
            VersionTransform.Y = 20;
            var sb = (Storyboard)FindResource("ShowVersionStoryboard");
            sb.Begin();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem is not Document selected)
            {
                MessageBox.Show("Сначала выберите версию документа.", "Комментарий",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var win = new AddComment(versionService, selected);
            win.Owner = this;
            win.ShowDialog();
        }
    }
}