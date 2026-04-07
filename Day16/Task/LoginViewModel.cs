using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Task
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private UserManager _userManager = new UserManager();
        public string UserName { get; set; }
        public string Password { get; set; }
        private string _statusMessage;
        public bool IsLoginSuccessful { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyname = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        public string StatusMessage
        {
            get => _statusMessage;
            set { _statusMessage = value; OnPropertyChanged(); }
        }
        public ICommand LoginCommand => new RelayCommand(Login);
        public ICommand RegisrterCommand => new RelayCommand(Register);
        private void Login()
        {
            var main = new MainWindow();
            if (_userManager.Authenticate(UserName, Password))
            {
                StatusMessage = "Успешный вход!";
                IsLoginSuccessful = true;

            }
            else
            {
                StatusMessage = "Ошибка авторизации!";
                IsLoginSuccessful = false;
            }
        }
        private void Register()
        {
            var main = new MainWindow();
            if (_userManager.RegisterUser(UserName, Password))
            {
                StatusMessage = "Регистрация успешна!";
                IsLoginSuccessful = true;
            }
            else
            {
                StatusMessage = "Пользователь уже существует!";
                IsLoginSuccessful= false;
            }
        }
    }
}
