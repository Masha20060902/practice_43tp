using DocumentVersion.Data;
using DocumentVersion.Model;
using DocumentVersion.Service;
using DocumentVersion.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
namespace DocumentVersion.View
{
    public partial class MainWindow : Window
    {
        private readonly VersionControlViewModel _vm;
        private readonly UsersFileWatcher _usersWatcher;
        public MainWindow()
        {
            InitializeComponent();
            using (var ctx = new DocsContext())
            {
                ctx.Database.EnsureCreated();
            }
            _vm = new VersionControlViewModel();
            DataContext = _vm;
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            _usersWatcher = new UsersFileWatcher(dir, "users.json");
            Loaded += MainWindow_Loaded;

        }
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
            LoadingOverlay.Visibility = Visibility.Collapsed;
            DataGrid.Visibility = Visibility.Visible;
        }
        private void DocumentsTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (DocumentsTreeView.SelectedItem is DocumentEntity doc)
            {
                _vm.SelectedDocument = doc;
            }

        }
        private void AddVersionDoc_Click(object sender, RoutedEventArgs e)
        {
            if (_vm.SelectedDocument == null)
            {
                MessageBox.Show("Сначала выберите документ.", "Новая версия",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var win = new AddVersionDocument(_vm);
            win.Owner = this;
            win.ShowDialog();
        }

        private async void DeleteVersion_Click(object sender, RoutedEventArgs e)
        {
            await _vm.DeleteVersionAsync();
        }

        private async void AddDoc_Click(object sender, RoutedEventArgs e)
        {
            string title = Microsoft.VisualBasic.Interaction.InputBox(
               "Введите название документа", "Новый документ", "Новый документ");

            if (string.IsNullOrWhiteSpace(title))
                return;
            var doc = new DocumentEntity
            {
                Title = title,
                CreatedAt = DateTime.Now.ToString("yyyy-MM-dd")
            };

            var ctx = new DocsContext();
            var repo = new DocumentRepository(ctx);
            await repo.AddAsync(doc);

            _vm.Documents.Add(doc);
        }

        private void ViewHistory_Click(object sender, RoutedEventArgs e)
        {
            if (_vm.SelectedDocument == null)
            {
                MessageBox.Show("Сначала выберите документ.", "История",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var win = new HistoryWindow(_vm.Versions);
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
            if (DataGrid.SelectedItem is not VersionEntity selected)
                return;

            VerNumber.Text = $"Версия: {selected.VersionNumber}";
            VerDate.Text = $"Дата: {selected.CreatedAt}";
            VerAuthor.Text = $"Автор: {selected.Author}";
            VerComment.Text = selected.Comment;

            VersionContent.Opacity = 0;
            VersionTransform.Y = 20;
            var sb = (Storyboard)FindResource("ShowVersionStoryboard");
            sb.Begin();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem is not VersionEntity selected)
            {
                MessageBox.Show("Сначала выберите версию документа.", "Комментарий",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var win = new AddComment(selected); // конструктор нужно переписать под VersionEntity
            win.Owner = this;
            win.ShowDialog();
            VerNumber.Text = $"Версия: {selected.VersionNumber}";
            VerDate.Text = $"Дата: {selected.CreatedAt}";
            VerAuthor.Text = $"Автор: {selected.Author}";
            VerComment.Text = selected.Comment;
            DataGrid.Items.Refresh();
        }

        private void ThemeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current is App app)
            {
                app.ToggleTheme();

                ThemeMenuItem.Header = app.IsDarkTheme
                    ? "Переключиться на светлую тему"
                    : "Переключиться на тёмную тему";
            }
        }
    }
}