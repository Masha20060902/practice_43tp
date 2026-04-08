using System.Windows;
namespace Task
{
    public partial class AddComment : Window
    {
        private readonly VersionService _versionService;
        private readonly Document _version;
        public AddComment(VersionService versionService, Document version)
        {
            InitializeComponent();
            _versionService = versionService;
            _version = version;
            Title.Text = _version.Title;
            Comment.Text = _version.Comment;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            _versionService.AddCommentToVersion(_version, Title.Text, Comment.Text);
            Close();
        }
    }
}
