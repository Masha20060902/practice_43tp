using System.Windows;
using System.Windows.Controls;
namespace Task
{
    public partial class LoginView : Window
    {
        private MainWindow mw = new MainWindow();
        public LoginView()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            (DataContext as LoginViewModel)!.Password = PasswordBox.Password;
        }

        private  void Button_Click(object sender, RoutedEventArgs e)
        {
            mw.Show();
            this.Close();
        }

        private  void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mw.Show();
            this.Close();
        }
    }
}
