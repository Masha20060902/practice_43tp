using DocumentVersion.ViewModel;
using System.Windows;
using System.Windows.Controls;
namespace DocumentVersion.View
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel vm)
                vm.Password = PasswordBox.Password;
        }
    }
}
