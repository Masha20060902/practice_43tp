using System.Windows;
namespace Task
{
    public partial class AddComment : Window
    {
        private readonly VersionEntity _version;
        private readonly VersionRepository _versionRepository;
        public AddComment(VersionEntity version)
        {
            InitializeComponent();
            _version = version;
            _versionRepository = new VersionRepository(new DocsContext());
            Title.Text = _version.Title;
            Comment.Text = _version.Comment;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            _version.Title = Title.Text;
            _version.Comment = Comment.Text;

            await _versionRepository.UpdateAsync(_version);
            Close();
        }
    }
}
