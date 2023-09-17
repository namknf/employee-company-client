using Repository;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CompanyEmployee.Desktop.View
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            var source = new List<string>()
            {
                "Manager",
                "Admin"
            };
            RoleComboBox.ItemsSource = source;
        }

        private async void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            var roles = new List<string>();
            var role = RoleComboBox.SelectedItem.ToString();
            roles.Add(role);
            var result = await AuthenticationRepository.RegistrationAsync(FirstNameTextBox.Text, UsernameTextBox.Text, SecondNameTextBox.Text, PhoneNumberTextBox.Text, PasswordTextBox.Password, EmailTextBox.Text, roles);
            if (result)
                MessageBox.Show("Регистрация прошла успешно. Перейдите на страницу авторизации");
            else
                MessageBox.Show("Не удалось зарегистрироваться. Проверьте правильность введенных данных");
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}
