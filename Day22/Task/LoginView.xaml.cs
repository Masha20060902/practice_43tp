using System.Windows;
using System.Windows.Controls;
namespace Task
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            (DataContext as LoginViewModel)!.Password = PasswordBox.Password;
        }
    }
}
