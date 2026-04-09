using System.IO.Pipes;
using System.Text;
using System.Windows;

namespace Task
{
    class NamedPipeChatServer
    {
        private ChatViewModel _vm;
        public NamedPipeChatServer(ChatViewModel vm)
        {
            _vm = vm;
        }
        public async System.Threading.Tasks.Task StartServer()
        {
            while (true)
            {
                using var server = new NamedPipeServerStream("LocalChatPipe", PipeDirection.In);
                await server.WaitForConnectionAsync();

                byte[] buffer = new byte[256];
                int bytesRead = await server.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        _vm.ReceiveMessage(message);
                    });
                }
            }
        }
    }
}