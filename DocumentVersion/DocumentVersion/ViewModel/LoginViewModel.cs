using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using DocumentVersion.Common;
using DocumentVersion.Service;
using DocumentVersion.View;

namespace DocumentVersion.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private UserManager _userManager = new UserManager();
        private string _userName;
        public string UserName
        {
            get => _userName;
            set { _userName = value; OnPropertyChanged(); }
        }
        private string _password;
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }
        private string _statusMessage;
        public string StatusMessage
        {
            get => _statusMessage;
            set { _statusMessage = value; OnPropertyChanged(); }
        }
        public bool IsLoginSuccessful { get; private set; }
        public ICommand LoginCommand => new RelayCommand(Login);
        public ICommand RegisrterCommand => new RelayCommand(Register);

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyname = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));


        private void Login()
        {
            if (_userManager.Authenticate(UserName, Password))
            {
                StatusMessage = "Успешный вход!";
                IsLoginSuccessful = true;
                var main = new MainWindow();
                main.Show();
                foreach (Window w in Application.Current.Windows)
                {
                    if (w is LoginView)
                    {
                        w.Close();
                        break;
                    }
                }
            }
            else
            {
                StatusMessage = "Ошибка авторизации!";
                IsLoginSuccessful = false;
            }
        }
        private void Register()
        {
            var username = UserName?.Trim();
            var password = Password?.Trim();
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6 || password.Length > 14)
            {
                StatusMessage = "Пароль должен быть от 6 до 14 символов.";
                IsLoginSuccessful = false;
                return;
            }
            if (_userManager.RegisterUser(username, password))
            {
                StatusMessage = "Регистрация успешна!";
                IsLoginSuccessful = true;
            }
            else
            {
                StatusMessage = "Пользователь уже существует!";
                IsLoginSuccessful = false;
            }

        }
    }
}
