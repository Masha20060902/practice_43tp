using DocumentVersion.Service;
using DocumentVersion.ViewModel;
using System.Windows;
namespace DocumentVersion.View
{
    public partial class Chat : Window
    {
        private ChatViewModel _vm;
        private readonly bool _isServer;
        public Chat(bool isServer)
        {
            InitializeComponent();
            _isServer = isServer;
            _vm = new ChatViewModel();
            DataContext = _vm;
            if (isServer)
            {
                var server = new NamedPipeChatServer(_vm);
                _ = server.StartServer();
            }
        }
    }
}
