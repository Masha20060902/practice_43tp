using System.IO.Pipes;
using System.Text;

namespace Task
{
    class NamedPipeChatClient
    {
        public async System.Threading.Tasks.Task SendMessage(string message)
        {
            using var client = new NamedPipeClientStream(".", "LocalChatPipe", PipeDirection.Out);
            await client.ConnectAsync();
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            await client.WriteAsync(buffer, 0, buffer.Length);
        }
    }
}
