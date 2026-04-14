using DocumentVersion.Common;
using DocumentVersion.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DocumentVersion.ViewModel
{
    class ChatViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public ObservableCollection<string> ChatMessage { get; } = new();
        private NamedPipeChatClient _chatClient = new();

        private string _messageText;
        public string MessageText
        {
            get => _messageText;
            set { _messageText = value; OnPropertyChanged(); }
        }
        public ICommand SendMessageCommand => new RelayCommand(async () =>
        {
            if (string.IsNullOrWhiteSpace(MessageText))
                return;

            await _chatClient.SendMessage(MessageText);
            ChatMessage.Add("Вы: " + MessageText);
            MessageText = "";
        });
        public void ReceiveMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return;
            ChatMessage.Add("Другой пользователь: " + message);
        }
    }
}
