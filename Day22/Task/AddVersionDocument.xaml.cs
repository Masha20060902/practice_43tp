using System.Windows;
namespace Task
{
    public partial class AddVersionDocument : Window
    {
        private readonly VersionControlViewModel _vm;
        public AddVersionDocument(VersionControlViewModel vm)
        {
            InitializeComponent();
            _vm = vm;

        }
        private async void AddV_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(Version.Text, out int num))
            {
                MessageBox.Show("Неверный номер версии");
                return;
            }

            if (!DateTime.TryParse(Date.Text, out var createdAt))
            {
                MessageBox.Show("Неверный формат даты");
                return;
            }

            if (string.IsNullOrWhiteSpace(Author.Text))
            {
                MessageBox.Show("Введите автора");
                return;
            }

            await _vm.AddVersionAsync(num, createdAt, Author.Text);
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
