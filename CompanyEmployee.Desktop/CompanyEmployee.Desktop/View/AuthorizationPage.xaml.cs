using Repository;
using System.Windows;
using System.Windows.Controls;

namespace CompanyEmployee.Desktop.View
{
    /// <summary>
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private async void AuthorizeButton_Click(object sender, RoutedEventArgs e)
        {
            var result = await AuthenticationRepository.AuthorizeAsync(PasswordTextBox.Password, UsernameTextBox.Text);
            if (result != null && result.Token != null)
            {
                Properties.Settings.Default.AccessToken = result.Token;
                Properties.Settings.Default.Save();
                Manager.MainFrame.Navigate(new CompanyPage());
            }
            else
                MessageBox.Show("Не удалось авторизоваться. Проверьте правильность введенных данных");
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RegistrationPage());
        }
    }
}
